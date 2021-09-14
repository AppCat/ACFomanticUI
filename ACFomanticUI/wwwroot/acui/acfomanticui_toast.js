import '/_content/ACUI.Shared/jquery/jquery-3.6.0.min.js';
import '/_content/ACFomanticUI/dist/components/transition.js';
import '/_content/ACFomanticUI/dist/components/dimmer.js';
import '/_content/ACFomanticUI/dist/components/toast.js';

export function shot(id, settings) {
    var element = $('#' + id);
    element.toast(settings);
}