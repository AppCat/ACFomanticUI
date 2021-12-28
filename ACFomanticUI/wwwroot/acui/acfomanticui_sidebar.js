import '/_content/ACUI.Shared/jquery/jquery-3.6.0.min.js';
import '/_content/ACFomanticUI/dist/components/transition.js';
import '/_content/ACFomanticUI/dist/components/dimmer.js';
import '/_content/ACFomanticUI/dist/components/sidebar.js';

// 初始化
export function settings(id, settings) {
    var element = $('#' + id);

    if (settings != undefined) {
        if (settings.contextId != undefined) {
            settings.context = $('#' + settings.contextId);
        }

    } else {
        settings = {};
    }

    settings.onVisible = function (e) {
        callback(id, 'onVisible', e);
    };

    settings.onShow = function (e) {
        callback(id, 'onShow', e);
    };

    settings.onChange = function (e) {
        callback(id, 'onChange', e);
    };

    settings.onHide = function (e) {
        callback(id, 'onHide', e);
    };

    settings.onHidden = function (e) {
        callback(id, 'onHidden', e);
    };

    element.sidebar(settings);
}

export function callback(id, name, e) {
    DotNet.invokeMethodAsync("ACFomanticUI", "HandleSidebarCallback", {
        id: id,
        name: name
    });
}

/// 侧边栏
export function toggle(id) {
    var element = $('#' + id);
    element
        .sidebar('toggle');
}