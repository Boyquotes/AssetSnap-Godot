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
	public partial class LibraryItems : LibraryComponent
	{
		private readonly string Title = "Total items";

		private int ItemCount = 0;

		/*
		** Component constructor
		**
		** @return void
		*/
		public LibraryItems()
		{
			Name = "LibraryItems";
			//_include = false;
		}
		
		/*
		** Initializes the component
		**
		** @return void
		*/
		public override void Initialize()
		{
			base.Initialize();
			AddTrait(typeof(Labelable));
			Initiated = true;
			
			Trait<Labelable>()
				.SetName("LibraryItemsCount")
				.SetText(Title + ": " + ItemCount)
				.SetType(Labelable.TitleType.HeaderSmall)
				.SetMargin(7, "top")
				.SetMargin(0, "bottom")	
				.SetMargin(5, "right")
				.SetMargin(5, "left")
				.SetHorizontalSizeFlags(Control.SizeFlags.ExpandFill)
				.SetVerticalSizeFlags(Control.SizeFlags.ShrinkCenter)
				.SetAlignment( Godot.HorizontalAlignment.Right )
				.Instantiate()
				.Select(0)
				.AddToContainer(Container);
		}
		
		public int GetItemCount() 
		{
			return ItemCount;
		}
		
		public void SetItemCount(int count ) 
		{
			ItemCount = count;
			
			if( 
				HasTrait<Labelable>() &&
				Trait<Labelable>().Select(0).IsValid()
			) 
			{
				Trait<Labelable>().SetText(Title + ": " + count);
			}
		}
	}
}