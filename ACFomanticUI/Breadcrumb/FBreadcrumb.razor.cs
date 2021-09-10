using ACUI.Extensions;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 面包屑
    /// A breadcrumb is used to show hierarchy between content
    /// 面包屑用于显示内容之间的层次结构
    /// </summary>
    public partial class FBreadcrumb : ACListComponentBase
    {
        /// <summary>
        /// 导航管理器
        /// </summary>
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        /// <summary>
        /// 前缀
        /// </summary>
        private const string _prefix = "ui";

        /// <summary>
        /// 后缀
        /// </summary>
        private const string _suffix = "breadcrumb";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            classMapper.Clear()
                .Add(_prefix)
                .If(nameof(Inverted).ToLowerInvariant(), () => Inverted)
                .GetIf(() => Size.ToClass(), () => Size != null)
                .Add(_suffix)
                ;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        protected override Task OnInitializedAsync()
        {
            NavigationManager.LocationChanged += NavigationManager_LocationChanged;
            if (Auto)
            {
                AutoCreateBreadcrumb();
            }
            return base.OnInitializedAsync();
        }

        /// <summary>
        /// 路径变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NavigationManager_LocationChanged(object sender, Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs e)
        {
            if (Auto)
            {
                AutoCreateBreadcrumb();
                StateHasChanged();
            }
        }

        /// <summary>
        /// 渲染后
        /// </summary>
        /// <param name="firstRender"></param>
        protected override void OnAfterRender(bool firstRender)
        {
            if (Auto && (Chips?.Any() ?? false))
            {
                if ((!SelectedKeys?.Any() ?? true) || SelectedKeys.Last() != Chips.Last().Content)
                {
                    SelectedKeys = new string[] { Chips.Last().Content };
                }
            }
        }               

        /// <summary>
        /// 自动创建面包屑
        /// </summary>
        protected void AutoCreateBreadcrumb()
        {
            var currentUri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);
            var segments = currentUri?.Segments;
            if (segments != null && (segments?.Any() ?? false) && segments.Length > 1)
            {
                var chips = new List<IFBChip>();
                for (int i = 0; i < segments.Length; i++)
                {
                    if (i == 0)
                        continue;

                    var segment = segments[i].ToInitialUpper();
                    var isLast = i == segments.Length - 1;

                    if (isLast)
                    {
                        chips.Add(new FBSectionConfig
                        {
                            Content = segment.Replace("/", string.Empty)
                        });
                    }
                    else
                    {
                        chips.Add(new FBSectionConfig
                        {
                            Content = segment.Replace("/", string.Empty),
                            Link = true,
                            Href = $"{ string.Join("", segments.Take(i + 1))}"
                        });
                    }

                    if (segment.Contains("/") && !isLast)
                    {
                        chips.Add(new FBDividerConfig
                        {
                            Content = " / ",
                            ContentTemplate = AutoDivider
                        });
                    }
                }
                Chips = new FBChipCollection(chips.ToArray());
            }
        }


        #region Parameter

        /// <summary>
        /// 屑
        /// </summary>
        [Parameter]
        public FBChipCollection Chips { get; set; } = new FBChipCollection(Array.Empty<IFBChip>());

        /// <summary>
        /// 自动生成
        /// 通过 uri 自动生成 Breadcrumb
        /// Automatically generate the Breadcrumb from the URL
        /// </summary>
        [Parameter]
        public bool Auto { get; set; }

        /// <summary>
        /// 自动间隔图标
        /// </summary>
        [Parameter]
        public string AutoDividerIcon { get; set; }

        /// <summary>
        /// 自动间隔符
        /// </summary>
        [Parameter]
        public RenderFragment AutoDivider { get; set; }

        /// <summary>
        /// 颜色翻转
        /// 面包屑可以被倒置
        /// A breadcrumb can be inverted
        /// </summary>
        [Parameter]
        public bool Inverted { get; set; }

        /// <summary>
        /// 尺寸
        /// 面包屑的大小可以不同
        /// A breadcrumb can vary in size
        /// </summary>
        public EnumMix<FSize> Size { get; set; }

        #endregion
    }
}
