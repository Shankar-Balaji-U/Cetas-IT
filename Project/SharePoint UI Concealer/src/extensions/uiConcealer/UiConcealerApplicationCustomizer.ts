import { Log } from '@microsoft/sp-core-library';
import {
  BaseApplicationCustomizer
} from '@microsoft/sp-application-base';
import { SPHttpClient, SPHttpClientResponse } from '@microsoft/sp-http';
// import { Dialog } from '@microsoft/sp-dialog';

import * as strings from 'UiConcealerApplicationCustomizerStrings';
import { sharepointDefaultStyleLinks, ACCESS_DENIED_HTML } from './helper';
import config from './config';

const LOG_SOURCE: string = 'UiConcealerApplicationCustomizer';

// interface IUIConcealerConfig {
//   allowAdmin: boolean;
//   completeSite: boolean;
//   listOfPageUrls: Array<string>;
//   blockAllUsers: boolean;
// }

/**
 * If your command set uses the ClientSideComponentProperties JSON input,
 * it will be deserialized into the BaseExtension.properties object.
 * You can define an interface to describe it.
 */

export interface IUIConcealerApplicationCustomizerProperties {
  blockAdmin: boolean;
  blockCompleteSite: boolean;
  blockAllUsers: boolean;
  listOfSiteUrls: Array<string>;
}

/** A Custom Action which can be run during execution of a Client Side Application */
export default class UiConcealerApplicationCustomizer
  extends BaseApplicationCustomizer<IUIConcealerApplicationCustomizerProperties> {
  public async onInit(): Promise<void> {
    // const pathnames: Array<string> = ['/sites/Hand-HeldTerminal/Lists/User/AllItems.aspx'];
    Log.info(LOG_SOURCE, `Initialized ${strings.Title}`);

    const isAdmin: boolean = await this.isAdminUser();
    const blockAdmin: boolean = config.blockAdmin;
    const blockAllUsers: boolean = config.blockAllUsers;
    const blockCompleteSite: boolean = config.blockCompleteSite;
    const blockableSites: string[] = config.listOfSiteUrls;

    // Check if user is blocked
    const hasUserAccess: boolean = !blockAllUsers && (!isAdmin || (isAdmin && !blockAdmin));
    
    if (!hasUserAccess) {
      return await this._hideWebPageLikeMS();
    }
    
    // Check if entire site should be blocked
    if (blockCompleteSite) {
      return await this._hideWebPageLikeMS();
    }
    
    // Check if current path is in the block list
    const blockableSite: boolean = blockableSites.some((blockedPath: string) => {
      // TODO: Add regex support
      return blockedPath === location.pathname;
      // If regex needed: return new RegExp(blockedPath).test(location.pathname);
    });

    if (blockableSite) {
      return await this._hideWebPageLikeMS();
    }
    
    return Promise.resolve();
  }

  private async isAdminUser(): Promise<boolean> {
    const webUrl = this.context.pageContext.web.absoluteUrl;
    const apiUrl = `${webUrl}/_api/web/effectiveBasePermissions`;
    
    const response: SPHttpClientResponse = await this.context.spHttpClient.get(apiUrl, SPHttpClient.configurations.v1);
    const data = await response.json();

    const fullControl = 0x40000000;
    return (data.High & fullControl) === fullControl;
  }

  // private _hideWebPage(): void {

  //   const customStyle: HTMLStyleElement = document.createElement('style');
  //   customStyle.textContent = `
  //   #SuiteNavPlaceholder,
  //   #spSiteHeader,
  //   #sp-appBar,
  //   #spLeftNav,
  //   section.mainContent,
  //   #sp-skipToContent {
  //     display: none !important;
  //   }

  //   .custom-hidder-screen {
  //     position: fixed;
  //     top: 0;
  //     left: 0;
  //     width: 100%;
  //     height: 100%;
  //     background-image: url('${DENIED_ACCESS_DATAURI}');
  //     background-size: cover;
  //     background-repeat: no-repeat;
  //     background-position: center;
  //     background-attachment: fixed;
  //     background-size: 45%;
  //     background-color: rgba(255, 255, 255, 1);
  //     z-index: 9999;
  //   }
  //   `;
  //   document.head.appendChild(customStyle);

  //   const customHidderScreen: HTMLDivElement = document.createElement('div');
  //   customHidderScreen.id = 'custom-hidder-screen';
  //   customHidderScreen.classList.add('custom-hidder-screen');
  //   document.body.appendChild(customHidderScreen);
  // }

  private async _hideWebPageLikeMS(): Promise<void> {
    // const customStyle: HTMLStyleElement = document.createElement('style');
    // customStyle.textContent = customCSSText;
    // document.head.appendChild(customStyle);

    const shouldHideElements: NodeListOf<HTMLElement> = document.querySelectorAll("body *:not(#ms-error-body):not(#ms-error-body *)");
    shouldHideElements.forEach(async (element: HTMLElement) => {
      element.style.display = await 'none';
    });

    const sharepointStyleLinks: Array<string> = sharepointDefaultStyleLinks;
    const linkElements: Array<HTMLLinkElement> = sharepointStyleLinks.map((styleLink: string) => {
      const linkElement = document.createElement('link');
      linkElement.rel = 'stylesheet';
      linkElement.type = 'text/css';
      linkElement.href = `${location.origin}${styleLink}`;
      return linkElement;
    });

    document.head.append(...linkElements);

    const accessDeniedElement: Element = this._text2html(ACCESS_DENIED_HTML);
    document.body.prepend(accessDeniedElement);
  }

  private _text2html(text: string): Element {
    const parser = new DOMParser();
    const doc = parser.parseFromString(text, 'text/html');
    return doc.body.children[0] as Element;
  }
}
