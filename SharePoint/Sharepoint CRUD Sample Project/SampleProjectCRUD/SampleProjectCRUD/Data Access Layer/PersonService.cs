using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleProjectCRUD.Models;
using Microsoft.SharePoint;

namespace SampleProjectCRUD.Data_Access_Layer
{
    public class PersonService
    {
        public void addPerson(Person person)
        {
            try
            {
                using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                {

                    using (SPWeb web = site.OpenWeb())
                    {

                        SPList splist = web.Lists.TryGetList("POC Persons");
                        if (splist != null)
                        {
                            SPListItem spListItem = splist.AddItem();
                            spListItem["Last_x0020_Name"] = person.lastName;
                            spListItem["First_x0020_Name"] = person.firstName;
                            splist.Update();
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public void updatePerson(Person person)
        {

            try
            {
                using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                {

                    using (SPWeb web = site.OpenWeb())
                    {

                        SPList splist = web.Lists.TryGetList("POC Persons");
                        if (splist != null)
                        {
                            SPListItem spListItem = splist.GetItemById(person.id);
                            spListItem["Last_x0020_Name"] = person.lastName;
                            spListItem["First_x0020_Name"] = person.firstName;
                            splist.Update();
                        }
                    }
                }
            }
            catch
            {
            }
        }
        public void deletePerson(int id)
        {
            try
            {
                using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                {

                    using (SPWeb web = site.OpenWeb())
                    {

                        SPList splist = web.Lists.TryGetList("POC Persons");
                        if (splist != null)
                        {

                            splist.Items.DeleteItemById(id);
                            splist.Update();
                        }
                    }
                }
            }
            catch
            {
            }
        }
        public Person retrievePerson(int id)
        {
            Person person = new Person();
            try
            {
                using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                {

                    using (SPWeb web = site.OpenWeb())
                    {

                        SPList splist = web.Lists.TryGetList("POC Persons");
                        if (splist != null)
                        {
                            SPListItem spListItem = splist.GetItemById(id);


                            person.id = Convert.ToInt32(spListItem["ID"]);
                            person.lastName = spListItem["Last_x0020_Name"].ToString();
                            person.firstName = spListItem["First_x0020_Name"].ToString();
                        }


                    }
                }
            }
            catch
            {
            }

            return person;
        }

        public List<Person> retrievePerson()
        {
            List<Person> personList = new List<Person>();
            try
            {
                using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                {

                    using (SPWeb web = site.OpenWeb())
                    {

                        SPList splist = web.Lists.TryGetList("POC Persons");

                        if (splist != null)
                        {
                            SPQuery spQuery = new SPQuery();
                            spQuery.Query = "<Where><Gt><FieldRef Name = 'ID'/><Value Type='Integer'>0</Value></Gt></Where> ";

                            SPListItemCollection spListItemCollection = splist.GetItems(spQuery);


                            foreach (SPListItem item in spListItemCollection)
                            {
                                Person person = new Person();
                                person.id = Convert.ToInt32(item["ID"]);
                                person.lastName = item["Last_x0020_Name"].ToString();
                                person.firstName = item["First_x0020_Name"].ToString();
                                personList.Add(person);
                                person = null;
                            }
                        }



                    }
                }
            }
            catch (Exception ex)
            {
            }

            return personList;
        }
    }
}
