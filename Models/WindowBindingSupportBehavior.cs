// ============================================================================
// 
// Window のバインド可能なプロパティーを増やすためのビヘイビア
// 
// ============================================================================

// ----------------------------------------------------------------------------
// 
// ----------------------------------------------------------------------------

using Microsoft.Xaml.Behaviors;

using System;
using System.Windows;

namespace TestActualSize.Models
{
	public class WindowBindingSupportBehavior : Behavior<Window>
	{
		// ====================================================================
		// public プロパティー
		// ====================================================================

		// FrameworkElement.ActualWidth をバインド可能にする
		public Double ActualWidth
		{
			get => (Double)GetValue(ActualWidthProperty);
			set => SetValue(ActualWidthProperty, value);
		}

		// Window.IsActive をバインド可能にする
		public Boolean IsActive
		{
			get => (Boolean)GetValue(IsActiveProperty);
			set => SetValue(IsActiveProperty, value);
		}

		// ====================================================================
		// public メンバー変数
		// ====================================================================

		// FrameworkElement.ActualWidth をバインド可能にする
		public static readonly DependencyProperty ActualWidthProperty =
				DependencyProperty.Register(nameof(ActualWidth), typeof(Double), typeof(WindowBindingSupportBehavior),
				new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

		// Window.IsActive をバインド可能にする
		public static readonly DependencyProperty IsActiveProperty =
				DependencyProperty.Register(nameof(IsActive), typeof(Boolean), typeof(WindowBindingSupportBehavior),
				new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, SourceIsActiveChanged));

		// ====================================================================
		// protected メンバー関数
		// ====================================================================

		// --------------------------------------------------------------------
		// アタッチ時の準備作業
		// --------------------------------------------------------------------
		protected override void OnAttached()
		{
			base.OnAttached();

			AssociatedObject.Activated += ControlActivated;
			AssociatedObject.Deactivated += ControlDeactivated;
			AssociatedObject.SizeChanged += ControlSizeChanged;
		}

		// ====================================================================
		// private メンバー関数
		// ====================================================================

		// --------------------------------------------------------------------
		// View 側で IsActive が変更された
		// --------------------------------------------------------------------
		private void ControlActivated(Object? sender, EventArgs args)
		{
			IsActive = true;
		}

		// --------------------------------------------------------------------
		// View 側で IsActive が変更された
		// --------------------------------------------------------------------
		private void ControlDeactivated(Object? sender, EventArgs args)
		{
			IsActive = false;
		}

		// --------------------------------------------------------------------
		// View 側で Size が変更された
		// --------------------------------------------------------------------
		private void ControlSizeChanged(Object? sender, EventArgs args)
		{
			ActualWidth = AssociatedObject.ActualWidth;
		}

		// --------------------------------------------------------------------
		// ViewModel 側で IsActive が変更された
		// --------------------------------------------------------------------
		private static void SourceIsActiveChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
		{
			if ((obj is not WindowBindingSupportBehavior thisObject) || thisObject.AssociatedObject == null)
			{
				return;
			}

			if ((Boolean)args.NewValue)
			{
				thisObject.AssociatedObject.Activate();
			}
		}
	}
}
