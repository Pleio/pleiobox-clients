﻿using System;
using MonoTouch.UIKit;
using LocalBox_Common;
using System.Drawing;

namespace LocalBox_iOS
{
    public abstract class BaseNode : UIView
    {
        public TreeNode Node { get; set; }

        public string NodePath { get; protected set; }

        protected BaseNode()
        {
        }

        protected BaseNode (IntPtr handle) : base (handle)
        {

        }


        public virtual void HideBackButton() {}

        public virtual void ShowBackButton() {}

        public virtual void ViewWillResize() {}
    }
}

