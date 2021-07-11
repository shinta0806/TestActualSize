// ============================================================================
// 
// メインウィンドウの ViewModel
// 
// ============================================================================

// ----------------------------------------------------------------------------
// ビヘイビアのテスト用プログラム
// ----------------------------------------------------------------------------

using Livet;
using Livet.Commands;

using System;
using System.Threading.Tasks;

namespace TestActualSize.ViewModels
{
	public class MainWindowViewModel : ViewModel
	{
		// ====================================================================
		// public プロパティー
		// ====================================================================

		// --------------------------------------------------------------------
		// View 通信用のプロパティー
		// --------------------------------------------------------------------

		// ウィンドウタイトル
		private String _title = "ビヘイビアのテスト";
		public String Title
		{
			get => _title;
			set => RaisePropertyChangedIfSet(ref _title, value);
		}

		// 設定幅
		private Double _width = 500.0;
		public Double Width
		{
			get => _width;
			set => RaisePropertyChangedIfSet(ref _width, value);
		}

		// 実際の幅
		private Double _actualWidth;
		public Double ActualWidth
		{
			get => _actualWidth;
			set => RaisePropertyChangedIfSet(ref _actualWidth, value);
		}

		// 設定高さ
		private Double _height = 250.0;
		public Double Height
		{
			get => _height;
			set => RaisePropertyChangedIfSet(ref _height, value);
		}

		// 実際の高さ
		private Double _actualHeight;
		public Double ActualHeight
		{
			get => _actualHeight;
			set => RaisePropertyChangedIfSet(ref _actualHeight, value);
		}

		// アクティブ化
		private Boolean _isActive;
		public Boolean IsActive
		{
			get => _isActive;
			set => RaisePropertyChangedIfSet(ref _isActive, value);
		}

		// --------------------------------------------------------------------
		// コマンド
		// --------------------------------------------------------------------

		#region アクティブボタンの制御
		private ViewModelCommand? _buttonActivateClickedCommand;

		public ViewModelCommand ButtonActivateClickedCommand
		{
			get
			{
				if (_buttonActivateClickedCommand == null)
				{
					_buttonActivateClickedCommand = new ViewModelCommand(ButtonActivateClicked);
				}
				return _buttonActivateClickedCommand;
			}
		}

		public async void ButtonActivateClicked()
		{
			await Task.Delay(5000);
			IsActive = true;
		}
		#endregion

		// ====================================================================
		// public メンバー関数
		// ====================================================================

		// --------------------------------------------------------------------
		// 初期化
		// --------------------------------------------------------------------
		public void Initialize()
		{
		}
	}
}
