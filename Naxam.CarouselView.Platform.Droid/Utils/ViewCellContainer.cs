﻿using System;
using Android.Content;
using Android.Support.V4.View;
using Android.Views;
using Naxam.Controls.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Naxam.Controls.Platform.Droid
{
    using Platform = Xamarin.Forms.Platform.Android.Platform;

	class ViewCellContainer : ViewGroup, INativeElementView
	{
		readonly Android.Views.View _parent;
		IVisualElementRenderer _renderer;
		ViewCell _viewCell;
		ViewGroup _view;

		public ViewCellContainer(Context context,
								 Android.Views.View parent,
								 ViewCell viewCell) : base(context)
		{
			_viewCell = viewCell;

			LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);

			_parent = parent;

			_renderer = Platform.CreateRenderer(_viewCell.View);
			Platform.SetRenderer(_viewCell.View, _renderer);

			_view = _renderer.ViewGroup;
			AddView(_view);

			UpdateIsEnabled();
		}

		public void Update(object data)
		{
			_viewCell.BindingContext = data;
		}

		public Element Element
		{
			get { return _viewCell; }
		}

		public override bool OnInterceptTouchEvent(MotionEvent ev)
		{
			if (!Enabled)
				return true;
			return base.OnInterceptTouchEvent(ev);
		}

		public void UpdateIsEnabled()
		{
			Enabled = _viewCell.IsEnabled;
		}

		protected override void OnLayout(bool changed, int l, int t, int r, int b)
		{
			double width = Context.FromPixels(r - l);
			double height = Context.FromPixels(b - t);

			Xamarin.Forms.Layout.LayoutChildIntoBoundingRegion(_renderer.Element, new Rectangle(0, 0, width, height));

			_renderer.UpdateLayout();

			System.Diagnostics.Debug.WriteLine($"{nameof(OnLayout)}: {r - l}x{b - t}");
		}

		protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
		{
			int width = MeasureSpec.GetSize(widthMeasureSpec);
			int height = MeasureSpec.GetSize(heightMeasureSpec);
			var x = _renderer.Element;

			SetMeasuredDimension(width, height);

			System.Diagnostics.Debug.WriteLine($"{nameof(OnMeasure)}: {width}x{height}");
		}
	}
}
