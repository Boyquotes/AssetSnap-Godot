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
	public partial class GroupBuilderEditorGroupObjectAdvancedContainer : GroupObjectComponent
	{
		private GroupBuilderEditorGroupObjectAdvancedContainerSphereCollision _GroupBuilderEditorGroupObjectAdvancedContainerSphereCollision;
		private GroupBuilderEditorGroupObjectAdvancedContainerConvexCollision _GroupBuilderEditorGroupObjectAdvancedContainerConvexCollision;
		private GroupBuilderEditorGroupObjectAdvancedContainerConcaveCollision _GroupBuilderEditorGroupObjectAdvancedContainerConcaveCollision;
		private GroupBuilderEditorGroupObjectAdvancedContainerSnapLayer _GroupBuilderEditorGroupObjectAdvancedContainerSnapLayer;
		
		public bool IsVisible()
		{
			return Trait<Containerable>()
				.Select(0)
				.IsVisible();
		}
		
		public void ToggleVisibility()
		{
			Trait<Containerable>()
				.Select(0)
				.ToggleVisible();
		}
		
		protected override void _RegisterTraits()
		{
			AddTrait(typeof(Containerable));
			AddTrait(typeof(Buttonable));
			AddTrait(typeof(Spinboxable));
			AddTrait(typeof(Labelable));
			
		}
		protected override void _InitializeFields()
		{
			Trait<Containerable>()
				.SetName("AdvancedRowContainer")
				.SetMargin(0)
				.SetMargin(20, "bottom")
				.SetHorizontalSizeFlags(Control.SizeFlags.ShrinkBegin)
				.SetVerticalSizeFlags(Control.SizeFlags.ShrinkBegin)
				.SetOrientation( Containerable.ContainerOrientation.Horizontal )
				.SetInnerOrientation( Containerable.ContainerOrientation.Vertical )
				.SetVisible( false )
				.Instantiate();

			Container BoxContainer = Trait<Containerable>().Select(0).GetInnerContainer();
		
			_InitializeSnapLayerControl(BoxContainer);
			_InitializeSphereCollisionControl(BoxContainer);
			_InitializeConvexCollisionControl(BoxContainer);
			_InitializeConcaveCollisionControl(BoxContainer);
		}
		
		protected override void _FinalizeFields()
		{
			Trait<Containerable>()
				.Select(0)
				.AddToContainer(
					Container
				);
		}
		
		private void _InitializeSnapLayerControl(Container innerContainer)
		{
			List<string> Components = new()
			{
				"GroupBuilderEditorGroupObjectAdvancedContainerSnapLayer"
			};
			
			if (_GlobalExplorer.Components.HasAll( Components.ToArray() )) 
			{
				_GroupBuilderEditorGroupObjectAdvancedContainerSnapLayer = GlobalExplorer.GetInstance().Components.Single<GroupBuilderEditorGroupObjectAdvancedContainerSnapLayer>(true);
				_GroupBuilderEditorGroupObjectAdvancedContainerSnapLayer.Container = innerContainer;
				_GroupBuilderEditorGroupObjectAdvancedContainerSnapLayer.Index = Index;
				_GroupBuilderEditorGroupObjectAdvancedContainerSnapLayer.Options = Options;
				_GroupBuilderEditorGroupObjectAdvancedContainerSnapLayer.Path = Path;
				_GroupBuilderEditorGroupObjectAdvancedContainerSnapLayer.Initialize();
			}
		}
		
		private void _InitializeSphereCollisionControl(Container innerContainer)
		{
			List<string> Components = new()
			{
				"GroupBuilderEditorGroupObjectAdvancedContainerSphereCollision"
			};
			
			if (_GlobalExplorer.Components.HasAll( Components.ToArray() )) 
			{
				_GroupBuilderEditorGroupObjectAdvancedContainerSphereCollision = GlobalExplorer.GetInstance().Components.Single<GroupBuilderEditorGroupObjectAdvancedContainerSphereCollision>(true);
				_GroupBuilderEditorGroupObjectAdvancedContainerSphereCollision.Container = innerContainer;
				_GroupBuilderEditorGroupObjectAdvancedContainerSphereCollision.Index = Index;
				_GroupBuilderEditorGroupObjectAdvancedContainerSphereCollision.Options = Options;
				_GroupBuilderEditorGroupObjectAdvancedContainerSphereCollision.Path = Path;
				_GroupBuilderEditorGroupObjectAdvancedContainerSphereCollision.Initialize();
			}
		}
		
		private void _InitializeConvexCollisionControl(Container innerContainer)
		{
			List<string> Components = new()
			{
				"GroupBuilderEditorGroupObjectAdvancedContainerConvexCollision"
			};
			
			if (_GlobalExplorer.Components.HasAll( Components.ToArray() )) 
			{
				_GroupBuilderEditorGroupObjectAdvancedContainerConvexCollision = GlobalExplorer.GetInstance().Components.Single<GroupBuilderEditorGroupObjectAdvancedContainerConvexCollision>(true);
				_GroupBuilderEditorGroupObjectAdvancedContainerConvexCollision.Container = innerContainer;
				_GroupBuilderEditorGroupObjectAdvancedContainerConvexCollision.Index = Index;
				_GroupBuilderEditorGroupObjectAdvancedContainerConvexCollision.Options = Options;
				_GroupBuilderEditorGroupObjectAdvancedContainerConvexCollision.Path = Path;
				_GroupBuilderEditorGroupObjectAdvancedContainerConvexCollision.Initialize();
			}
		}
		
		private void _InitializeConcaveCollisionControl(Container innerContainer)
		{
			List<string> Components = new()
			{
				"GroupBuilderEditorGroupObjectAdvancedContainerConcaveCollision"
			};
			
			if (_GlobalExplorer.Components.HasAll( Components.ToArray() )) 
			{
				_GroupBuilderEditorGroupObjectAdvancedContainerConcaveCollision = GlobalExplorer.GetInstance().Components.Single<GroupBuilderEditorGroupObjectAdvancedContainerConcaveCollision>(true);
				_GroupBuilderEditorGroupObjectAdvancedContainerConcaveCollision.Container = innerContainer;
				_GroupBuilderEditorGroupObjectAdvancedContainerConcaveCollision.Index = Index;
				_GroupBuilderEditorGroupObjectAdvancedContainerConcaveCollision.Options = Options;
				_GroupBuilderEditorGroupObjectAdvancedContainerConcaveCollision.Path = Path;
				_GroupBuilderEditorGroupObjectAdvancedContainerConcaveCollision.Initialize();
			}
		}
	}
}