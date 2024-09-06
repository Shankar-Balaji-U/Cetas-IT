const environment = Microsoft.Dynamics.NAV.GetEnvironment();

const TOAST_MAIN_SELECTOR_ID = 'toast-notif-main';
const TOAST_HEAD_SELECTOR_ID = 'toast-notif-head';
const TOAST_HEAD_TEXT_SELECTOR_ID = 'toast-heading';
const TOAST_HEAD_ICON_SELECTOR_ID = 'toast-logo';

const TOAST_BODY_SELECTOR_ID = 'toast-notif-body';
const TOAST_STYLE_SELECTOR_ID = 'toasts-notify-stylesheet';

const rootdocument = GetRootDocument();

function ToastsHTML() {
    const cetasLogo = Microsoft.Dynamics.NAV.GetImageResource('src/controladdin/global-static/img/Cetas-Logo-Color.png');
    const HTMLText =
`<div class="toast-container position-fixed bottom-0 end-0 p-3">
    <div id="${TOAST_MAIN_SELECTOR_ID}" class="toast" role="alert" aria-live="assertive" aria-atomic="true">
        <div class="toast-header ps-1" id="${TOAST_HEAD_SELECTOR_ID}">
            <img id="${TOAST_HEAD_ICON_SELECTOR_ID}" src="${cetasLogo}" style="height:1.25rem" class="rounded me-2 w-auto" alt="cetas logo">
            <strong class="me-auto" id="${TOAST_HEAD_TEXT_SELECTOR_ID}">Bootstrap</strong>
            <small>just now</small>
            <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
        </div>
        <div class="toast-body" id="${TOAST_BODY_SELECTOR_ID}">
            <!-- Message Here... -->
        </div>
    </div>
</div>`;
    const parse = new DOMParser();
    const html = parse.parseFromString(HTMLText, 'text/html');
    
    return html.body.children;
}

function SetToastsHtml() {
    if (rootdocument.getElementById(TOAST_MAIN_SELECTOR_ID) === null) {
        const toasthtml = ToastsHTML();
        rootdocument.body.append(...toasthtml);
    }
}

// const rootdocument = GetRootDocument();

// rootdocument.append();

function Notify(Value) {
}


function NotifyWithTitle(Title, Message) {
    SetToastsHtml();
    
    var toastEl = rootdocument.querySelector(`#${TOAST_MAIN_SELECTOR_ID}`);
    var toastHeadingEl = toastEl.querySelector(`#${TOAST_HEAD_TEXT_SELECTOR_ID}`);
    var toastBodyEl = toastEl.querySelector(`#${TOAST_BODY_SELECTOR_ID}`);

    toastHeadingEl.textContent = Title;
    toastBodyEl.textContent = Message;

    try {
    const toast = new bootstrap.Toast(toastEl);
    const closeBtn = toastEl.querySelector('[data-bs-dismiss="toast"]');
    if (closeBtn) {
        closeBtn.addEventListener('click', () => toast.hide());
    }
    
    toast.show();
    rootdocument.toast = toast;
    } catch(ex) {
        console.log(ex);
    }
}

environment.OnClosed = function(event) {
    console.log('Closed:', event);
}