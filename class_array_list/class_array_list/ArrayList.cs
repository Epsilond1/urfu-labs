using System.Collections.Generic;

namespace class_array_list
{
    public class ArrayList
    {
        public List<string> listDisciplines = new List<string>();
        public bool isAlphavite;

        public bool getIsAlphavite
        {
            get { return isAlphavite; }
            set { isAlphavite = value; } 
        }

        public List<string> getListDisc
        {
            get { return listDisciplines; }
        }

        public void addList(string discipline)
        {
            listDisciplines.Add(discipline);
        }

        public void rmDiscipline(int id)
        {
            listDisciplines.RemoveAt(id);
        }

        public void clearListDisciplines()
        {
            listDisciplines.Clear();
        }

        public bool ContainsDiscipline(string discipline)
        {
            return listDisciplines.Contains(discipline) ? true : false;
        }
    }
}
