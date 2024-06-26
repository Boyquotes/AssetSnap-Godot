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
	using AssetSnap.Component;
	using Godot;

	[Tool]
	public partial class LibraryBody : LibraryComponent
	{
		/*
		** Constructor of component
		** 
		** @return void
		*/
		public LibraryBody()
		{
			Name = "LibraryBody";
			//_include = false;
		}
		
		/*
		** Initialization of component
		** 
		** @return void
		*/
		public override void Initialize()
		{
			base.Initialize();
			AddTrait(typeof(Containerable));
			Initiated = true;
			
			if( Container is PanelContainer PanelContainer ) 
			{
				Trait<Containerable>()
					.SetName("MainLibraryContainer")
					.SetMargin(5)
					.SetLayout(Containerable.ContainerLayout.TwoColumns)
					.SetHorizontalSizeFlags(Control.SizeFlags.ExpandFill)
					.SetVerticalSizeFlags(Control.SizeFlags.ExpandFill)
					.Instantiate()
					.Select(0)
					.AddToContainer( PanelContainer );

				Container container = Trait<Containerable>()
					.Select(0)
					.GetInnerContainer(0);
					
				Container containerTwo = Trait<Containerable>()
					.Select(0)
					.GetInnerContainer(1);

				container.SizeFlagsHorizontal = Control.SizeFlags.ShrinkBegin;
				container.SizeFlagsVertical = Control.SizeFlags.ExpandFill;
				container.CustomMinimumSize = new Vector2(225,0);
			}
		}
			
		/*
		** Fetches the left inner container
		**
		** @return VBoxContainer
		*/
		public VBoxContainer GetLeftInnerContainer() 
		{
			return Trait<Containerable>()
					.Select(0)
					.GetInnerContainer(0) as VBoxContainer;
		}
		
		/*
		** Fetches the right inner container
		**
		** @return VBoxContainer
		*/
		public VBoxContainer GetRightInnerContainer() 
		{
			return Trait<Containerable>()
					.Select(0)
					.GetInnerContainer(1) as VBoxContainer;
		} 
	}
}