using ACUI.Shared.Core.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 表单
    /// 表单以结构化的方式显示一组相关的用户输入字段
    /// A form displays a set of related user input fields in a structured way
    /// </summary>
    public partial class FForm<TModel> : ACContentComponentBase<TModel>, IFForm
    {

        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "form";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .If("equal width", () => EqualWidth)
                .If(nameof(Disabled).ToLowerInvariant(), () => Disabled)
                .If(nameof(Loading).ToLowerInvariant(), () => Loading)
                .If(nameof(Inverted).ToLowerInvariant(), () => Inverted)
                .GetIf(() => States.ToClass(), () => States != null)
                .GetIf(() => Size.ToClass(), () => Size != null)
                .Add(_suffix)
                ;
        }

        /// <summary>
        /// 模型
        /// </summary>
        object IFForm.Model => Model;

        /// <summary>
        /// 编辑上下文
        /// </summary>
        EditContext IFForm.EditContext => _editContext;
        private EditContext _editContext;

        /// <summary>
        /// 表单项
        /// </summary>
        private IList<IFField> _fields = new List<IFField>();

        /// <summary>
        /// 控制值
        /// </summary>
        private IList<IControlValueAccessor> _controls = new List<IControlValueAccessor>();

        #region Parameter

        /// <summary>
        /// 表单消息模板
        /// </summary>
        [Parameter]
        public RenderFragment<TModel> FormMessageTemplate { get; set; }

        /// <summary>
        /// 启用表单消息
        /// </summary>
        [Parameter]
        public bool EnableFormMessage { get; set; } = true;

        /// <summary>
        /// 自动
        /// 通过 Model, 自动生成表单
        /// With the Model, the form is automatically generated
        /// </summary>
        [Parameter]
        public bool Auto { get; set; }

        /// <summary>
        /// 模型
        /// </summary>
        [Parameter]
        public TModel Model
        {
            get { return _model; }
            set
            {
                if (!(_model?.Equals(value) ?? false))
                {
                    _model = value;
                    _editContext = new EditContext(Model);
                }
            }
        }
        private TModel _model;

        /// <summary>
        /// 加载中
        /// 如果表单处于加载状态，它将自动显示加载指示器。
        /// If a form is in loading state, it will automatically show a loading indicator.
        /// </summary>
        [Parameter]
        public bool Loading { get; set; }

        /// <summary>
        /// 等宽
        /// 表单可以自动将字段划分为相等的宽度
        /// Forms can automatically divide fields to be equal width
        /// </summary>
        [Parameter]
        public bool EqualWidth { get; set; }

        /// <summary>
        /// 颠倒
        /// 表单可以自动将字段划分为相等的宽度
        /// A form on a dark background may have to invert its color scheme
        /// </summary>
        [Parameter]
        public bool Inverted { get; set; }

        /// <summary>
        /// 尺寸
        /// A form can vary in size
        /// 表格的大小可以不同
        /// </summary>
        [Parameter]
        public EnumMix<FSize>  Size { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 成功
        /// </summary>
        [Parameter]
        public EventCallback<EditContext> OnFinish { get; set; }

        /// <summary>
        /// 失败
        /// </summary>
        [Parameter]
        public EventCallback<EditContext> OnFailed { get; set; }

        /// <summary>
        /// 重置
        /// </summary>
        [Parameter]
        public EventCallback<EditContext> OnReset { get; set; }

        /// <summary>
        /// 在有效的提交
        /// </summary>
        /// <param name="editContext"></param>
        /// <returns></returns>
        private async Task OnValidSubmit(EditContext editContext)
        {
            await OnFinish.InvokeAsync(editContext);
        }

        /// <summary>
        /// 在无效的提交
        /// </summary>
        /// <param name="editContext"></param>
        /// <returns></returns>
        private async Task OnInvalidSubmit(EditContext editContext)
        {
            await OnFailed.InvokeAsync(editContext);
        }

        #endregion

        /// <summary>
        /// 状态
        /// </summary>
        public EnumMix<FStates>  States { get; set; }

        /// <summary>
        /// 重置
        /// </summary>
        public void Reset()
        {
            _controls?.ForEach(control => control.Reset());
            _editContext = new EditContext(Model);
            OnReset.InvokeAsync(_editContext);
        }

        /// <summary>
        /// 提交
        /// </summary>
        public void Submit()
        {
            var isValid = Validate();
            if (isValid && OnFinish.HasDelegate)
                OnFinish.InvokeAsync(_editContext);
            else if (OnFailed.HasDelegate)
                OnFailed.InvokeAsync(_editContext);
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            return _editContext?.Validate() ?? false;
        }

        /// <summary>
        /// 添加表单项
        /// </summary>
        /// <param name="field"></param>
        void IFFieldGroup.AddFormItem(IFField field)
        {
            _fields?.Add(field);
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        /// <param name="valueAccessor"></param>
        void IFFieldGroup.AddControl(IControlValueAccessor valueAccessor)
        {
            _controls?.Add(valueAccessor);
        }
    }
}
