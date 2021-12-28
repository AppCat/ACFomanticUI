using ACUI.FomanticUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACFomanticUI.Demo.Pages
{
    public partial class Modal
    {
        /// <summary>
        /// 显示模态
        /// </summary>
        /// <returns></returns>
        async Task ShowModalAsync()
        {
            var student = new Student();
            FForm<Student> form = null;
            var templateSettings = new FMTemplateSettings
            {
                ContentTemplate = tag => _builder =>
                {
                    _builder.OpenComponent<FForm<Student>>(0);
                    _builder.AddAttribute(1, "Model", student);
                    _builder.AddAttribute(2, "Auto", true);
                    _builder.AddComponentReferenceCapture(3, edit => { form = (FForm<Student>)edit; Console.WriteLine("Form"); });
                    _builder.CloseComponent();
                },
                Actions = new[]
                {
                    new FMATemplateSettings
                    {
                        Text = "取消",
                        Colored = FColored.Red,
                        Class = "deny",

                    },
                    new FMATemplateSettings
                    {
                        Text = "确认",
                        Colored = FColored.Green,
                        Class = "approve",
                    }
                },
            };

            await _modalService.ShowModalAsync(templateSettings);
        }
    }
}
