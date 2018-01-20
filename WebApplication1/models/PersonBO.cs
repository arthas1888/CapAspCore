using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.models
{
    public class PersonBO : CRUD<Person>
    {
        public List<Person> PersonList;

        public PersonBO()
        {
            PersonList = new List<Person>();
        }

        public Person Create(Person model)
        {
            if (PersonList.Any(x => x.DocNum == model.DocNum))
                return null;

            PersonList.Add(model);
            return model;
        }

        public List<Person> Read()
        {
            return PersonList;
        }

        public Person Retrieve(int id)
        {
            return PersonList.SingleOrDefault(obj => obj.DocNum == id);
        }

        public Person Update(int id, Person model)
        {
            Person res = null;
            for (int i = 0; i < PersonList.Count(); i++)
            {
                if (PersonList[i].DocNum == id)
                {
                    PersonList[i] = model;
                    res = model;
                    break;
                }
            }
            return res;
        }

        public Person Delete(int id)
        {
            var entity = PersonList.SingleOrDefault(x => x.DocNum == id);
            if (entity != null)
                PersonList.Remove(entity);
            return entity;
        }
    }
}
