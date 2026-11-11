namespace LAB;

public static class ListTasks
{
    public static int CountDistinct<T>(List<T> list)
    {
        if (list == null || list.Count == 0) return 0;

        List<T> unique = new List<T>();
        foreach (T item in list)
        {
            if (!unique.Contains(item))
            {
                unique.Add(item);
            }
        }

        return unique.Count;
    }

    public static void ReplaceUnequalNeighbors(LinkedList<string> list, string E, string F)
    {
        if (list == null || list.Count < 3) return;
        
        List<LinkedListNode<string>> nodesToReplace = new List<LinkedListNode<string>>();
        
        LinkedListNode<string> current = list.First.Next;

        while (current.Next != null)
        {
            if (current.Value == E && current.Previous.Value != current.Next.Value)
            {
                nodesToReplace.Add(current.Previous);
                nodesToReplace.Add(current.Next);
            }

            current = current.Next;
        }
        foreach (LinkedListNode<string> node in nodesToReplace)
        {
            node.Value = F;
        }
    }

    public static (List<string> InAll, List<string> InSome, List<string> InOne) 
        AnalyzeCrops(List<List<string>> cooperatives)
    {
        List<string> inAll = new List<string>();
        List<string> inSome = new List<string>();
        List<string> inOne = new List<string>();

        int n = cooperatives.Count;
        if (n == 0) return (inAll, inSome, inOne);
        
        List<HashSet<string>> coopSets = new List<HashSet<string>>();
        
        HashSet<string> allUniqueCrops = new HashSet<string>();
        
        for (int i = 0; i < n; i++)
        {
            HashSet<string> currentSet = new HashSet<string>(cooperatives[i]);
            coopSets.Add(currentSet);
            foreach (string crop in currentSet)
            {
                allUniqueCrops.Add(crop);
            }
        }
        
        foreach (string crop in allUniqueCrops)
        {
            int count = 0;

            for (int c = 0; c < coopSets.Count; c++)
            {
                if (coopSets[c].Contains(crop))
                {
                    count++;
                }
            }
            if (count == n)
                inAll.Add(crop);
            else if (count > 1 && count < n)
                inSome.Add(crop);
            else if (count == 1)
                inOne.Add(crop);
        }
        return (inAll, inSome, inOne);
    }
    
    public static List<char> FindCommonChars(string text)
    {
        List<char> result = new List<char>();

        if (string.IsNullOrWhiteSpace(text)) return result;
        
        char[] separators = { ' ', '\t', '\n', '\r', '.', ',', '!', '?', ';', ':', '-', '—', '(', ')', '"', '«', '»' };
        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        int totalWords = words.Length;
        if (totalWords == 0) return result;
        
        List<HashSet<char>> wordSets = new List<HashSet<char>>();
        for (int i = 0; i < totalWords; i++)
        {
            wordSets.Add(new HashSet<char>(words[i].ToLower()));
        }
        
        HashSet<char> firstWord = wordSets[0];
        
        foreach (char ch in firstWord)
        {
            bool inAllWords = true;
            
            for (int i = 1; i < wordSets.Count; i++)
            {
                if (!wordSets[i].Contains(ch))
                {
                    inAllWords = false;
                    break;
                }
            }
            
            if (inAllWords)
            {
                result.Add(ch);
            }
        }
        return result;
    }
}