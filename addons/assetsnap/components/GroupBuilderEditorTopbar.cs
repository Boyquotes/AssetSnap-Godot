// MIT License

// Copyright (c) 2024 Mike Sørensen

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

namespace AssetSnap.Front.Components
{
	using System.Collections.Generic;
	using AssetSnap.Component;
	using Godot;

	[Tool]
	public partial class GroupBuilderEditorTopbar : LibraryComponent
	{

		public GroupBuilderEditorTopbar()
		{
			Name = "GroupBuilderEditorTopbar";
			//_include = false;
		}	
		
		public GroupBuilderEditorTitleInput TitleInput { set; get; }
		public GroupBuilderEditorPlace PlaceButton { set; get; }
		public GroupBuilderEditorSave SaveButton { set; get; }
		public GroupBuilderEditorClose CloseButton { set; get; }
		
		private MarginContainer _MarginContainer;
		private HBoxContainer _BoxContainer;
		private MarginContainer _InnerMarginContainer;
		private HBoxContainer _InnerBoxContainer;
		private MarginContainer totalMarginContainer;
		private Label _TotalItems;

		public override void Initialize()
		{
			Initiated = true;
			
			_InitializeFields();
			
			_MarginContainer.AddThemeConstantOverride("margin_left", 15);
			_MarginContainer.AddThemeConstantOverride("margin_right", 15);
			_MarginContainer.AddThemeConstantOverride("margin_top", 10);
			_MarginContainer.AddThemeConstantOverride("margin_bottom", 0);

			_SetupGroupTitle(_BoxContainer);
			
			_SetupCloseButton(_InnerBoxContainer);
			_SetupPlaceButton(_InnerBoxContainer);
			
			_InnerMarginContainer.AddChild(_InnerBoxContainer);
			_BoxContainer.AddChild(_InnerMarginContainer);
			_MarginContainer.AddChild(_BoxContainer);
			
			Container.AddChild(_MarginContainer);
		}
			
		public void UpdateTotalItems( int items )
		{
			if( null != totalMarginContainer && null != _TotalItems && 0 != items) 
			{
				_TotalItems.Text = "Total items in group: " + items;
				totalMarginContainer.Visible = true;
			}
			else if( null != totalMarginContainer && null != _TotalItems )
			{
				totalMarginContainer.Visible = false;
			}
		}
		
		public void Update()
		{
			if ( _GlobalExplorer.GroupBuilder._Editor.Group == null || false == IsInstanceValid(_GlobalExplorer.GroupBuilder._Editor.Group) )
			{
				if( IsInstanceValid( SaveButton ) ) 
				{
					SaveButton.Hide();
				}
				if( IsInstanceValid( CloseButton ) ) 
				{
					CloseButton.Hide();
				}
				if( IsInstanceValid( PlaceButton ) ) 
				{
					PlaceButton.Hide();
				}
				if( IsInstanceValid( TitleInput ) ) 
				{
					TitleInput.Update();
				}

				UpdateTotalItems(0);
			
				return;
			}
			
			if( IsInstanceValid( SaveButton ) ) 
			{
				SaveButton.Show();
			}
			if( IsInstanceValid( CloseButton ) ) 
			{
				CloseButton.Show();
			}
			if( IsInstanceValid( PlaceButton ) ) 
			{
				PlaceButton.Show();
			}
			if( IsInstanceValid( TitleInput ) ) 
			{
				TitleInput.Update();
			}
		
			UpdateTotalItems(_GlobalExplorer.GroupBuilder._Editor.Group._Paths.Count);
		}
		
		public string GetTitle() 
		{
			return TitleInput._InputField.Text;
		}
		
		public bool TitleEquals( string Name )
		{
			return Name == TitleInput._InputField.Text;
		}
		
		private void _InitializeFields()
		{
			_MarginContainer = new();
			_BoxContainer = new();
			_InnerMarginContainer = new()
			{
				SizeFlagsHorizontal = Control.SizeFlags.ExpandFill
			};
			_InnerBoxContainer = new()
			{
				SizeFlagsHorizontal = Control.SizeFlags.ShrinkEnd
			};
		}
	
		
		private void _SetupGroupTitle( HBoxContainer container )
		{
			List<string> Components = new()
			{
				"GroupBuilderEditorSave",
				"GroupBuilderEditorTitleInput",
			};
			
			HBoxContainer hBoxContainer = new();

			totalMarginContainer = new()
			{
				Visible = false,
			};
			totalMarginContainer.AddThemeConstantOverride("margin_right", 200);
			HBoxContainer totalInnerContainer = new();
			
			_TotalItems = new()
			{
				Text = "Total items in group: " + 0,
				ThemeTypeVariation = "HeaderSmall",
			};
			
			Label _label = new()
			{
				Text = "Active Group",
				ThemeTypeVariation = "HeaderMedium",
			};
			
			totalInnerContainer.AddChild(_TotalItems);
			totalMarginContainer.AddChild(totalInnerContainer);
			hBoxContainer.AddChild(totalMarginContainer);
			hBoxContainer.AddChild(_label);
			
			if ( _GlobalExplorer.Components.HasAll( Components.ToArray() )) 
			{
				TitleInput = _GlobalExplorer.Components.Single<GroupBuilderEditorTitleInput>();
				TitleInput.Container = hBoxContainer;
				TitleInput.Initialize();
				
				SaveButton = _GlobalExplorer.Components.Single<GroupBuilderEditorSave>();
				SaveButton.Container = hBoxContainer;
				SaveButton.Initialize();
			}
			
			container.AddChild(hBoxContainer);
		}
		
		private void _SetupCloseButton( HBoxContainer container )
		{
			List<string> Components = new()
			{
				"GroupBuilderEditorClose",
			};
			
			if (_GlobalExplorer.Components.HasAll( Components.ToArray() )) 
			{
				CloseButton = _GlobalExplorer.Components.Single<GroupBuilderEditorClose>();
				CloseButton.Container = container;
				CloseButton.Initialize();
			}
		}
		
		private void _SetupPlaceButton( HBoxContainer container )
		{
			List<string> Components = new()
			{
				"GroupBuilderEditorPlace",
			};
			
			if (_GlobalExplorer.Components.HasAll( Components.ToArray() )) 
			{
				PlaceButton = _GlobalExplorer.Components.Single<GroupBuilderEditorPlace>();
				PlaceButton.Container = container;
				PlaceButton.Initialize();
			}
		}

		public override void _ExitTree()
		{
			if( null != _TotalItems && IsInstanceValid(_TotalItems) ) 
			{
				_TotalItems.QueueFree();
			}
			if( null != totalMarginContainer && IsInstanceValid(totalMarginContainer) ) 
			{
				totalMarginContainer.QueueFree();
			}
			if( null != TitleInput && IsInstanceValid(TitleInput) ) 
			{
				TitleInput.QueueFree();
			}
			if( null != PlaceButton && IsInstanceValid(PlaceButton) ) 
			{
				PlaceButton.QueueFree();
			}
			if( null != SaveButton && IsInstanceValid(SaveButton) ) 
			{
				SaveButton.QueueFree();
			}
			if( null != CloseButton && IsInstanceValid(CloseButton) ) 
			{
				CloseButton.QueueFree();
			}

			if( null != _InnerBoxContainer && IsInstanceValid(_InnerBoxContainer) ) 
			{
				_InnerBoxContainer.QueueFree();
			}
			
			if( null != _InnerMarginContainer && IsInstanceValid(_InnerMarginContainer) ) 
			{
				_InnerMarginContainer.QueueFree();
			}
			
			if( null != _MarginContainer && IsInstanceValid(_MarginContainer) ) 
			{
				_MarginContainer.QueueFree();
			}
			
			if( null != _BoxContainer && IsInstanceValid(_BoxContainer) ) 
			{
				_BoxContainer.QueueFree();
			}
			
			base._ExitTree(); 
		}
	}
}