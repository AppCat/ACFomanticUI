import '/_content/ACUI.Shared/jquery/jquery-3.6.0.min.js';
import '/_content/ACFomanticUI/dist/components/transition.js';
import '/_content/ACFomanticUI/dist/components/dimmer.js';
import '/_content/ACFomanticUI/dist/components/modal.js';

export function set(id, settings, templateSettings) {
    var element = $('#' + id);
    if (settings != undefined) {
        element.modal(settings);
    }
    if (templateSettings != undefined) {
        element.modal(templateSettings);
    }
}

export function show(id) {
    var element = $('#' + id);

    element.modal({       
        onDeny: function (e) {
            return callback(id, 'onDeny', e);
        },
        onApprove: function (e) {
            return callback(id, 'onApprove', e);
        },
        onHide: function (e) {
            return callback(id, 'onHide', e);
        },
        onShow: function (e) {
            callback(id, 'onShow', e);
        },
        onVisible: function (e) {
            callback(id, 'onVisible', e);
        },      
        onHidden: function (e) {
            callback(id, 'onHidden', e);
        }
    });

    element.modal('show');
}

export function callback(id, name, e) {
    var r = DotNet.invokeMethod("ACFomanticUI", "HandleModalCallback", {
        id: id,
        name: name
    });
    if (r != undefined) {
        return r;
    }
}