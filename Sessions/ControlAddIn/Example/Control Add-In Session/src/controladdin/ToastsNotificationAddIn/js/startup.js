const frameEl = GetCurrentFrame();

frameEl.style.display = 'none';

// Hello, world! This is a toast message.
const rootdocument = GetRootDocument();

const bootstrapFilePath = Microsoft.Dynamics.NAV.GetImageResource('src/controladdin/global-static/css/bootstrap.css');

if (!!bootstrapFilePath && !rootdocument.querySelector(`head #${TOAST_STYLE_SELECTOR_ID}`)) {
    const bootstrapStyleSheet = document.createElement('LINK');
    bootstrapStyleSheet.type = 'text/css';
    bootstrapStyleSheet.rel = 'stylesheet';
    bootstrapStyleSheet.id = TOAST_STYLE_SELECTOR_ID;
    bootstrapStyleSheet.href = bootstrapFilePath;

    rootdocument.head.append(bootstrapStyleSheet);
}