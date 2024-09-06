const COLOR = '#212121';
const BACKGROUND_COLOR = '#D9F0F2';

function createTextElement(text) {
    const element = document.createElement('SPAN');
    element.textContent = text;
    element.style.textAlign = 'center';
    return element;
}

function GetRootDocument() {
    function _getDocument($document) {
        if (!$document.defaultView.frameElement) {
            return $document;
        }
        return _getDocument($document.defaultView.frameElement.ownerDocument);
    }
    return _getDocument(document);
}

function GetCurrentFrame() {
    return document.defaultView.frameElement;
}

document.addEventListener('DOMContentLoaded', (event) => {
    const controlAddIn = document.querySelector('#controlAddIn');
    controlAddIn.style.backgroundColor = BACKGROUND_COLOR;
    controlAddIn.style.display = 'flex';
    controlAddIn.style.justifyContent = 'center';
    controlAddIn.style.alignItems = 'center';
});