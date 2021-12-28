using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.FomanticUI
{
    /// <summary>
    /// 评论
    /// 评论显示用户对网站内容的反馈
    /// A comment displays user feedback to site content
    /// </summary>
    public partial class FComment : ACComponentBase
    {
        /// <summary>
        /// 后缀
        /// </summary>
        private const string _fixed = "comment";

        /// <summary>
        /// 设置类
        /// </summary>
        /// <param name="classMapper"></param>
        protected override void OnSetClass(Mapper classMapper)
        {
            ClassMapper.Clear()
            .If(nameof(HoldRight).ToLowerInvariant(), () => HoldRight)
            .Add(_fixed)
            ;

            AuthorStyleMapper.Clear()
            .Get(() => AuthorConfig?.AsStyle)
            ;

            AuthorClassMapper.Clear()
            .Add("author")
            .Get(() => AuthorConfig?.AsClass)
            .If(nameof(HoldRight).ToLowerInvariant(), () => HoldRight)
            ;

            MetadataStyleMapper.Clear()
            .Get(() => MetadataConfig?.AsStyle)
            ;

            MetadataClassMapper.Clear()
            .Add("metadata")
            .Get(() => MetadataConfig?.AsClass)
            .If(nameof(HoldRight).ToLowerInvariant(), () => HoldRight)
            ;

            TextStyleMapper.Clear()
            .Get(() => TextConfig?.AsStyle)
            ;

            TextClassMapper.Clear()
            .Add("text")
            .Get(() => TextConfig?.AsClass)
            ;

            ActionsStyleMapper.Clear()
            .Get(() => ActionsConfig?.AsStyle)
            ;

            ActionsClassMapper.Clear()
            .Add("actions")
            .Get(() => ActionsConfig?.AsClass)
            ;

            ContentStyleMapper.Clear()
            .Get(() => ContentConfig?.AsStyle)
            ;

            ContentClassMapper.Clear()
            .Get(() => ContentConfig?.AsClass)
            .If(nameof(HoldRight).ToLowerInvariant(), () => HoldRight)
            ;

            AvatarStyleMapper.Clear()
            .Get(() => AvatarConfig?.AsStyle)
            ;

            AvatarClassMapper.Clear()
            .Add("avatar")
            .If(nameof(HoldRight).ToLowerInvariant(), () => HoldRight)
            .Get(() => AvatarConfig?.AsClass)
            ;

            ChildCommentsStyleMapper.Clear()
            .Get(() => AvatarConfig?.AsStyle)
            ;

            ChildCommentsClassMapper.Clear()
            .Get(() => AvatarConfig?.AsClass)
            ;
        }


        /// <summary>
        /// 内容样式 映射
        /// </summary>
        protected Mapper ContentStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 内容类 映射
        /// </summary>
        protected Mapper ContentClassMapper { get; set; } = new Mapper();

        /// <summary>
        /// 作者样式 映射
        /// </summary>
        protected Mapper AuthorStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 作者类 映射
        /// </summary>
        protected Mapper AuthorClassMapper { get; set; } = new Mapper();

        /// <summary>
        /// 元数据样式 映射
        /// </summary>
        protected Mapper MetadataStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 元数据类 映射
        /// </summary>
        protected Mapper MetadataClassMapper { get; set; } = new Mapper();

        /// <summary>
        /// 文本样式 映射
        /// </summary>
        protected Mapper TextStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 文本类 映射
        /// </summary>
        protected Mapper TextClassMapper { get; set; } = new Mapper();

        /// <summary>
        /// 文本样式 映射
        /// </summary>
        protected Mapper ActionsStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 文本类 映射
        /// </summary>
        protected Mapper ActionsClassMapper { get; set; } = new Mapper();

        /// <summary>
        /// 头像样式 映射
        /// </summary>
        protected Mapper AvatarStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 头像类 映射
        /// </summary>
        protected Mapper AvatarClassMapper { get; set; } = new Mapper();

        /// <summary>
        /// 子评论样式 映射
        /// </summary>
        protected Mapper ChildCommentsStyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 子评论类 映射
        /// </summary>
        protected Mapper ChildCommentsClassMapper { get; set; } = new Mapper();

        

        #region Parameter

        /// <summary>
        /// 靠右
        /// </summary>
        [Parameter]
        public bool HoldRight { get; set; }

        /// <summary>
        /// 头像内容
        /// </summary>
        [Parameter]
        public RenderFragment AvatarContent { get; set; }

        /// <summary>
        /// 头像配置
        /// </summary>
        [Parameter]
        public ACComponentConfig AvatarConfig { get; set; }

        /// <summary>
        /// 内容配置
        /// </summary>
        [Parameter]
        public ACComponentConfig ContentConfig { get; set; }

        /// <summary>
        /// 作者 配置
        /// </summary>
        [Parameter]
        public ACComponentConfig AuthorConfig { get; set; }

        /// <summary>
        /// 作者内容
        /// </summary>
        [Parameter]
        public RenderFragment AuthorContent { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [Parameter]
        public string Author { get; set; }

        /// <summary>
        /// 元数据 配置
        /// </summary>
        [Parameter]
        public ACComponentConfig MetadataConfig { get; set; }

        /// <summary>
        /// 元数据
        /// </summary>
        [Parameter]
        public string[] Metadata { get; set; }

        /// <summary>
        /// 元数据内容
        /// </summary>
        [Parameter]
        public RenderFragment MetadataContent { get; set; }

        /// <summary>
        /// 文本 配置
        /// </summary>
        [Parameter]
        public ACComponentConfig TextConfig { get; set; }

        /// <summary>
        /// 文本
        /// </summary>
        [Parameter]
        public string Text { get; set; }

        /// <summary>
        /// 文本内容
        /// </summary>
        [Parameter]
        public RenderFragment TextContent { get; set; }

        /// <summary>
        /// 行为 配置
        /// </summary>
        [Parameter]
        public ACComponentConfig ActionsConfig { get; set; }

        /// <summary>
        /// 行为
        /// </summary>
        [Parameter]
        public string[] Actions { get; set; }

        /// <summary>
        /// 行为内容
        /// </summary>
        [Parameter]
        public RenderFragment ActionsContent { get; set; }

        /// <summary>
        /// 子评论
        /// </summary>
        [Parameter]
        public RenderFragment ChildCommentsContent { get; set; }

        /// <summary>
        /// 子评论配置
        /// </summary>
        [Parameter]
        public ACComponentConfig ChildCommentsConfig { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 点击头像
        /// </summary>
        [Parameter]
        public EventCallback OnClickAvatar { get; set; }

        /// <summary>
        /// 点击作者
        /// </summary>
        [Parameter]
        public EventCallback<string> OnClickAuthor { get; set; }

        /// <summary>
        /// 点击行为事件
        /// </summary>
        [Parameter]
        public EventCallback<string> OnClickAction { get; set; }

        #endregion
    }
}
