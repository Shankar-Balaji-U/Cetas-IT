var controlAddIn;

const pop = function(object, key) {
    let value = object[key];
    delete object[key];
    return value;
}

const createElement = function (tagname, options={}) {
    let element = document.createElement(tagname);
    let labelledBy = pop(options, 'ariaLabelledby');
    let children = pop(options, 'children');

    if (options['required'])
        options['ariaRequired'] = options['required'];

    element = Object.assign(element, options);
    if (labelledBy !== undefined && labelledBy !== null) {
        element.setAttribute('aria-labelledby', labelledBy);
    }

    if (children !== undefined && children.length > 0)
        element.append(...children);

    return element;
}

function Init() {
    if (controlAddIn instanceof Element) { 
        return;
    }

    controlAddIn = document.getElementById('controlAddIn');
    var formControlContainer = createElement('DIV', {
        className: 'form-container',
        children: [
            formLabel = createElement('SPAN', {
                className: 'form-label'
            }),
            formControl = createElement('INPUT', {
                type: 'range',
                className: 'ms-form-range'
            })
        ]
    });

    controlAddIn.append(formControlContainer);
    formControl.addEventListener('change', function(event) {
        Microsoft.Dynamics.NAV.InvokeExtensibilityMethod('OnValidate', [event.target.value]);
    });
}

function SetValue(value) {
    formControl.value = value;
}

function SetConfig(settings) {
    if (settings.max) {
        formControl.max = settings.max;
    }
    if (settings.min) {
        formControl.min = settings.min;
    }
    if (settings.step) {
        formControl.step = settings.step;
    }
}