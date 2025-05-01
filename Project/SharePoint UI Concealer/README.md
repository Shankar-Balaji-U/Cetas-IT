# **Getting Started with SharePoint Framework (SPFx)**

## **Overview**
SharePoint Framework (SPFx) is a client-side development framework used to build customizations for SharePoint. It is built using TypeScript and uses web technologies like React, Node.js, and modern JavaScript tooling.

## **Customizing the Application: UI Concealer**

To achieve the project goal, we modified the default SPFx Application Customizer inside the `src/extensions` folder (typically under a name like `UiConcealer`). The custom code is used to **conditionally hide the SharePoint user interface** based on site-specific access rules.

### **Purpose**
The primary objective of this customization is to:
- Hide the SharePoint UI for non-admin users or all users.
- Block access to specific pages or the entire site.
- Display a custom "Access Denied" screen using SPFx.

### **Key Features**
- Admin detection using SharePoint permissions API.
- Config-driven conditional rendering logic.
- Dynamic DOM manipulation to hide SharePoint UI.
- Support for loading fallback styles and injecting custom HTML.

---

## **Prerequisites**
Before starting development with SPFx, you must install several development tools and dependencies.

### 1. **Node.js Runtime**
SPFx projects require a specific version of Node.js (typically a long-term support (LTS) version). You can download Node.js from [https://nodejs.org/](https://nodejs.org/).

### 2. **Gulp**
Gulp is a JavaScript task runner used for automating development workflows. In SPFx, it's commonly used to:
- Bundle and minify JavaScript and CSS files.
- Run build tasks before packaging the solution.
- Compile LESS or Sass into CSS.
- Compile TypeScript into JavaScript.

You can install it globally using:
```bash
npm install -g gulp
```

### 3. **Yeoman and SharePoint Generator**
Yeoman helps scaffold projects using generators. The `@microsoft/sharepoint` generator scaffolds SPFx projects.

Install Yeoman and the SharePoint generator:
```bash
npm install -g yo
npm install -g @microsoft/generator-sharepoint
```

### 4. **SharePoint Package**
The `@microsoft/sharepoint` package is part of the generated project and is automatically included during scaffolding.

## **Development Environment**
- It is recommended to use **Visual Studio Code** for SPFx development.
- Make sure you also have **Git** installed to manage source control if needed.

## **Create a New SPFx Project**

1. Create a folder for your project:
   ```bash
   mkdir my-spfx-project
   cd my-spfx-project
   ```

2. Run the SharePoint Yeoman generator:
   ```bash
   yo @microsoft/sharepoint
   ```

   This will prompt you with configuration questions and scaffold the project structure.

## **Project Structure**
After scaffolding, your project will have a standard SPFx structure. Most of your development will take place inside the `/src` folder, which contains the components and logic for your web parts or extensions.

## **Code Summary**

The file `UiConcealerApplicationCustomizer.ts` has been modified with the following logic:

### **1. Configuration Handling**
The extension uses an imported `config` object with the following structure:

```ts
{
  blockAdmin: boolean;             // Whether to block admin users
  blockAllUsers: boolean;         // Whether to block all users
  blockCompleteSite: boolean;     // Whether to block the entire site
  listOfSiteUrls: string[];       // Specific site paths to block
}
```

### **2. Admin User Detection**
An internal method `isAdminUser()` uses the SharePoint REST API (`_api/web/effectiveBasePermissions`) to check if the current user has `Full Control` permission:

```ts
const webUrl = this.context.pageContext.web.absoluteUrl;
const apiUrl = `${webUrl}/_api/web/effectiveBasePermissions`;

const response: SPHttpClientResponse = await this.context.spHttpClient.get(apiUrl, SPHttpClient.configurations.v1);
const data = await response.json();
const fullControl = 0x40000000;
return (data.High & fullControl) === fullControl;
```

### **3. UI Concealment Logic**
The main logic inside `onInit()` evaluates:
- Whether the current user is blocked.
- Whether the site or current URL is blocked.
- Whether the entire site should be blocked for all users.

If any condition matches, the `_hideWebPageLikeMS()` method is triggered.

```ts
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
```

### **4. UI Hiding Mechanism**
This method:
- Selects all DOM elements (`body *`) **except** a specific element (`#ms-error-body`), and sets `display: none`.
- Injects SharePoint default CSS using `<link>` elements to retain base styling.
- Prepends a custom "Access Denied" HTML layout to the page using `ACCESS_DENIED_HTML`.

### **5. Helper Function**
```ts
   // function _text2html(text: string): Element
   const parser = new DOMParser();
   const doc = parser.parseFromString(text, 'text/html');
   return doc.body.children[0] as Element;
```
Parses raw HTML text into an actual DOM element to be inserted into the document.

---

## **Folder Structure Overview**
```
src/
└── extensions/
    └── uiConcealer/
        ├── UiConcealerApplicationCustomizer.ts     <-- Modified main logic
        ├── config.ts                               <-- Contains configuration flags
        └── helper.ts                               <-- Contains constants and HTML templates
```

---

## **Building and Deploying the SPFx Solution**

After completing development of your SPFx project, follow these steps to build, bundle, package, and deploy your solution to SharePoint.

---

### **Step 1: Build the Project**
Before packaging, ensure the solution builds without errors:

```bash
gulp clean
gulp build
```
---

### **Step 2: Bundle the Assets**
Bundle your code and prepare assets to be deployed:

```bash
gulp bundle --ship
```

The `--ship` flag indicates a production (release) build.

---

### **Step 3: Package the Solution**
Generate the `.sppkg` file for deployment to the App Catalog:

```bash
gulp package-solution --ship
```

> ⚠️ **Note on Versioning**  
Sometimes the `.sppkg` file doesn’t reflect new changes due to cache or deployment issues.  
To ensure your changes take effect:
1. Open `config/package-solution.json`
2. Manually **increment the version** (e.g., from `1.0.0.0` to `1.0.0.1`)
3. Re-run the packaging commands.

```json
"solution": {
  "name": "ui-concealer-client-side-solution",
  "version": "1.0.0.1",
  ...
}
```

---

### **Step 4: Upload to App Catalog**
1. Go to your **SharePoint App Catalog** site.
2. Upload the `.sppkg` file from `./sharepoint/solution/ui-concealer.sppkg`.
3. In the popup, check **"Make this solution available to all sites in the organization"** if needed.
4. Click **Deploy**.

---

### **Step 5: Install in Site**
To install the app in a specific SharePoint site:
1. Navigate to the **Site Contents** of the desired site.
2. Click **Add an App**.
3. Find and select your deployed solution (e.g., "UI Concealer").
4. Click **Add** to install it.

---

## **Development Tips**

### **Preview Your Extension Locally**

To preview your SPFx extension during development, use:

```bash
gulp serve
```

This uses a local Node.js server to run your extension in a **SharePoint Workbench**.

### **SharePoint Workbench Setup**

- **Local Workbench**: Runs at `https://localhost:4321/temp/workbench.html`  
  No SharePoint context — good for testing rendering only.

- **Online Workbench (Recommended for Real Testing)**:  
  Navigate to:  
  ```
  https://<your-tenant>.sharepoint.com/sites/<yoursite>/_layouts/15/workbench.aspx
  ```

### **Configure `serve.json` for Extensions**

In `config/serve.json`, define your component configuration like this:

```json
{
  "$schema": "https://developer.microsoft.com/json-schemas/core-build/serve.schema.json",
  "port": 4321,
  "https": true,
  "initialPage": "https://yourtenant.sharepoint.com/sites/yoursite/_layouts/15/workbench.aspx",
  "serveConfigurations": {
    "default": {
      "pageUrl": "https://yourtenant.sharepoint.com/sites/yoursite/SitePages/Home.aspx",
      "customActions": {
        "12345678-90ab-cdef-1234-567890abcdef": {
          "location": "ClientSideExtension.ApplicationCustomizer",
          "properties": {}
        }
      }
    }
  }
}
```

   This initiates a local development server that hosts your SPFx solution. For Application Customizers, which cannot be tested using the local workbench, you can configure the serve.json file to specify a SharePoint page (`pageUrl`) where the extension will be temporarily loaded.

> Replace the GUID with your extension’s **ID** from `src/UiConcealerApplicationCustomizer.manifest.json`.

---

### ✅ **Tips**
- Always run `gulp clean` before bundling for a fresh build.
- Use versioning properly to prevent caching issues.
- Use local and hosted workbench to test real SharePoint integration.
- Validate network requests using browser dev tools while debugging.
- Use feature toggles or `config.ts` to manage dev/prod behavior cleanly.

---

## **Result**
Once deployed, this extension will monitor each page load. Based on the config, it will selectively block access for users or paths, and inject a styled "Access Denied" message in place of the SharePoint UI.

## **Reference**
- [SharePoint Framework development tools and libraries | Microsoft Learn](https://learn.microsoft.com/sharepoint/dev/spfx/sharepoint-framework-overview)
