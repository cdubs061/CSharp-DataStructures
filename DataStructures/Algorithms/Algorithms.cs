namespace MyDataStructures;

class SortingAlgorithms
{
	public int[] BubbleSort(int[] array) 
	{
		int length = array.Length - 1;
		bool swapped = true;		

		while (swapped)
		{
			swapped = false;
			for (int i = 0; i < length; i++)
			{
				if (array[i] > array[i+1])
				{
					int temp = array[i];
					array[i] = array[i+1];
					array[i+1] = temp;
					swapped = true;
				}
			}
		}
		return array;
	}

	public int[] InsertionSort(int[] array)
	{
		int i = 1;
		while (i < array.Length) 
		{
			int j = i;
			while (j > 0 && array[j] < array[j-1])
			{
				int temp = array[j];
				array[j] = array[j-1];
				array[j-1] = temp;
				j--;
			}
			i++;
		}
		return array;
	}

	public int[] SelectionSort(int[] array)
	{
		for (int i = 0; i < array.Length; i++)
		{
			int min = array[i];
			int minIndex = i;
			for (int j = i; j < array.Length; j++)
			{
				if (array[j] < min)
				{
					min = array[j];
					minIndex = j;
				}
			}

			int temp = array[minIndex];
			array[minIndex] = array[i];
			array[i] = temp;
		}
		return array;
	}

	public int[] MergeSort(int[] array)
	{
		if (array.Length <= 1) 
    	{
		    return array;
    	}
	
		
		int[] array2 = new int[array.Length];
		TopDownSplit(0, array.Length);
		return array2;		 
			
		void TopDownSplit(int iStart, int iEnd) 
		{
			if (iEnd - iStart <= 1) 
			{
				return;
			}

			int middle = (iStart + iEnd) / 2;
			
			TopDownSplit(iStart, middle);
			TopDownSplit(middle, iEnd);

			TopDownMerge(iStart, middle, iEnd);
		}
		
		void TopDownMerge(int num1, int middle, int num2) 
		{	
			int i = num1;
			int j = middle;

			for (int k = num1; k < num2; k++)
			{
				if (i < middle && (j >= num2 || array[i] <= array[j])) 
				{
					array2[k] = array[i];
					i++;
				}
				else
				{
					array2[k] = array[j];
					j++;
				}	
			}

			for (int k = num1; k < num2; k++)
        		{
            			array[k] = array2[k];
        		}
		}
	}
	
	public int[] QuickSort(int[] array)
	{
		int pivot = array.Length - 1;
		Quick(array, 0, pivot);
	
		int Partition(int[] array, int start, int end)
		{
			int pivot = end;
			int j = start-1;
			for (int i = start; i <= end; i++)
			{
				if (array[i] < array[pivot])
				{
					j++;
					int temp = array[j];
					array[j] = array[i];
					array[i] = temp;
				}
			}
			int temp2 = array[pivot];
			array[pivot] = array[j+1];
			array[j+1] = temp2;
			return j+1;
		}	

		void Quick(int[] array, int start, int end) 
		{
			if (start < end)	
			{
				int pi = Partition(array, start, end);
				
				Quick(array, start, pi-1);
				Quick(array, pi+1, end);
			}
		
		}

		return array;
	}

    public int HeightChecker(int[] heights) 
    {
        int count = 0;
        int[] expected = new int[heights.Length];
        for (int i = 0; i < heights.Length; i++) 
        {
            int min = heights[i];
            int minIndex = i;
            for (int j = i; j < heights.Length; j++) 
            {
                if (heights[j] < min) 
                {
                    min = heights[j];
                    minIndex = j;
                }
            }
            expected[i] = min;
        }
        Console.WriteLine(String.Join(",", expected));
        
        for (int i = 0; i < heights.Length; i++) 
        {
            if (heights[i] != expected[i]) 
            {
                count++;
            }
        }
        
        return count;
    }
}
