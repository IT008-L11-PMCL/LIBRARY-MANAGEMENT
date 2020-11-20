﻿namespace LIBRARY.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup1 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem1 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup2 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem2 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem3 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem4 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup3 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem5 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Books = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Cards = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement5 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.author = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Readers = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.barLargeButtonItem1 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.skinBarSubItem1 = new DevExpress.XtraBars.SkinBarSubItem();
            this.barLargeButtonItem2 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.galleryDropDown1 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            this.repositoryItemFontEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemFontEdit();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.galleryDropDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement1,
            this.accordionControlElement2});
            this.accordionControl1.Location = new System.Drawing.Point(0, 31);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(250, 470);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            this.accordionControl1.MouseEnter += new System.EventHandler(this.accordionControl1_MouseEnter);
            this.accordionControl1.MouseLeave += new System.EventHandler(this.accordionControl1_MouseLeave);
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "Home";
            // 
            // accordionControlElement2
            // 
            this.accordionControlElement2.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.Books,
            this.Cards,
            this.accordionControlElement5,
            this.author,
            this.Readers});
            this.accordionControlElement2.Expanded = true;
            this.accordionControlElement2.Name = "accordionControlElement2";
            this.accordionControlElement2.Text = "Library";
            // 
            // Books
            // 
            this.Books.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Books.ImageOptions.SvgImage")));
            this.Books.Name = "Books";
            this.Books.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.Books.Text = "Books";
            // 
            // Cards
            // 
            this.Cards.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Cards.ImageOptions.SvgImage")));
            this.Cards.Name = "Cards";
            this.Cards.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.Cards.Text = "Cards";
            this.Cards.Click += new System.EventHandler(this.accordionControlElement4_Click);
            // 
            // accordionControlElement5
            // 
            this.accordionControlElement5.Name = "accordionControlElement5";
            this.accordionControlElement5.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement5.Text = "Book Management";
            this.accordionControlElement5.Click += new System.EventHandler(this.accordionControlElement5_Click);
            // 
            // author
            // 
            this.author.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("author.ImageOptions.SvgImage")));
            this.author.Name = "author";
            this.author.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.author.Text = "Authors";
            // 
            // Readers
            // 
            this.Readers.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Readers.ImageOptions.SvgImage")));
            this.Readers.Name = "Readers";
            this.Readers.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.Readers.Text = "Readers";
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barLargeButtonItem1,
            this.barSubItem1,
            this.skinBarSubItem1,
            this.barLargeButtonItem2,
            this.barButtonItem1});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemFontEdit1});
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(874, 31);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.skinBarSubItem1);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.barButtonItem1);
            // 
            // barLargeButtonItem1
            // 
            this.barLargeButtonItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barLargeButtonItem1.Id = 1;
            this.barLargeButtonItem1.Name = "barLargeButtonItem1";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barSubItem1.Id = 3;
            this.barSubItem1.Name = "barSubItem1";
            // 
            // skinBarSubItem1
            // 
            this.skinBarSubItem1.Caption = "Theme";
            this.skinBarSubItem1.Id = 8;
            this.skinBarSubItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("skinBarSubItem1.ImageOptions.SvgImage")));
            this.skinBarSubItem1.Name = "skinBarSubItem1";
            this.skinBarSubItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            // 
            // barLargeButtonItem2
            // 
            this.barLargeButtonItem2.ActAsDropDown = true;
            this.barLargeButtonItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barLargeButtonItem2.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barLargeButtonItem2.Caption = "AD";
            this.barLargeButtonItem2.Id = 10;
            this.barLargeButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barLargeButtonItem2.ImageOptions.SvgImage")));
            this.barLargeButtonItem2.Name = "barLargeButtonItem2";
            this.barLargeButtonItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.ActAsDropDown = true;
            this.barButtonItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItem1.Caption = "Profile";
            this.barButtonItem1.DropDownControl = this.galleryDropDown1;
            this.barButtonItem1.Id = 12;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // galleryDropDown1
            // 
            // 
            // 
            // 
            galleryItemGroup1.Caption = "Profile";
            galleryItem1.Caption = "Profile";
            galleryItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("resource.SvgImage")));
            galleryItemGroup1.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            galleryItem1});
            galleryItemGroup2.Caption = "Account";
            galleryItem2.Caption = "Sign in";
            galleryItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("resource.SvgImage1")));
            galleryItem3.Caption = "Register a new account";
            galleryItem3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("resource.SvgImage2")));
            galleryItem4.Caption = "Log out";
            galleryItem4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("resource.SvgImage3")));
            galleryItemGroup2.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            galleryItem2,
            galleryItem3,
            galleryItem4});
            galleryItemGroup3.Caption = "System";
            galleryItem5.Caption = "Close";
            galleryItem5.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("resource.SvgImage4")));
            galleryItemGroup3.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            galleryItem5});
            this.galleryDropDown1.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            galleryItemGroup1,
            galleryItemGroup2,
            galleryItemGroup3});
            this.galleryDropDown1.Manager = this.fluentFormDefaultManager1;
            this.galleryDropDown1.Name = "galleryDropDown1";
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.DockingEnabled = false;
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barLargeButtonItem1,
            this.barSubItem1,
            this.skinBarSubItem1,
            this.barLargeButtonItem2,
            this.barButtonItem1});
            this.fluentFormDefaultManager1.MaxItemId = 16;
            this.fluentFormDefaultManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemFontEdit1});
            // 
            // repositoryItemFontEdit1
            // 
            this.repositoryItemFontEdit1.AutoHeight = false;
            this.repositoryItemFontEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemFontEdit1.Name = "repositoryItemFontEdit1";
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.MenuManager = this.fluentFormDefaultManager1;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // tabbedView1
            // 
            this.tabbedView1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabbedView1.Appearance.Options.UseBorderColor = true;
            this.tabbedView1.Appearance.Options.UseFont = true;
            this.tabbedView1.Appearance.Options.UseTextOptions = true;
            this.tabbedView1.AppearancePage.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabbedView1.AppearancePage.Header.Options.UseBorderColor = true;
            this.tabbedView1.AppearancePage.Header.Options.UseFont = true;
            this.tabbedView1.AppearancePage.Header.Options.UseTextOptions = true;
            this.tabbedView1.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabbedView1.AppearancePage.HeaderActive.Options.UseBorderColor = true;
            this.tabbedView1.AppearancePage.HeaderActive.Options.UseFont = true;
            this.tabbedView1.AppearancePage.HeaderActive.Options.UseTextOptions = true;
            this.tabbedView1.AppearancePage.HeaderDisabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabbedView1.AppearancePage.HeaderDisabled.Options.UseBorderColor = true;
            this.tabbedView1.AppearancePage.HeaderDisabled.Options.UseFont = true;
            this.tabbedView1.AppearancePage.HeaderDisabled.Options.UseTextOptions = true;
            this.tabbedView1.AppearancePage.HeaderHotTracked.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabbedView1.AppearancePage.HeaderHotTracked.Options.UseBorderColor = true;
            this.tabbedView1.AppearancePage.HeaderHotTracked.Options.UseFont = true;
            this.tabbedView1.AppearancePage.HeaderHotTracked.Options.UseTextOptions = true;
            this.tabbedView1.AppearancePage.HeaderSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabbedView1.AppearancePage.HeaderSelected.Options.UseBorderColor = true;
            this.tabbedView1.AppearancePage.HeaderSelected.Options.UseFont = true;
            this.tabbedView1.AppearancePage.HeaderSelected.Options.UseTextOptions = true;
            this.tabbedView1.AppearancePage.PageClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabbedView1.AppearancePage.PageClient.Options.UseBorderColor = true;
            this.tabbedView1.AppearancePage.PageClient.Options.UseFont = true;
            this.tabbedView1.AppearancePage.PageClient.Options.UseTextOptions = true;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 2";
            this.bar1.DockCol = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Custom 2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 501);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.NavigationControl = this.accordionControl1;
            this.Text = "Library Management";
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.galleryDropDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Books;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Cards;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement5;
        private DevExpress.XtraBars.Navigation.AccordionControlElement author;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Readers;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.SkinBarSubItem skinBarSubItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemFontEdit repositoryItemFontEdit1;
        private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.GalleryDropDown galleryDropDown1;
        private DevExpress.XtraBars.Bar bar1;
    }
}