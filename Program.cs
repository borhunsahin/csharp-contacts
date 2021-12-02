using System;
using System.Collections.Generic;
using System.Linq;

namespace csharps_contacts
{
    class Program
    {
        static void Main(string[] args)
        {
            Contacts contacts = new Contacts();
            
            contacts.add_contact(new Person("Sponge Bob","Squarepants","6115746"));
            contacts.add_contact(new Person("Patrick","Star","48974321"));
            contacts.add_contact(new Person("Squidward","Tentacles","59774378"));
            contacts.add_contact(new Person("Eugene Harold","Krabs","78945678"));
            contacts.add_contact(new Person("Sandra Jennifer","Cheeks","94816545"));

            
            while(true)
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
                Console.WriteLine("*******************************************");
                Console.WriteLine("(1) Yeni Numara Kaydetmek");
                Console.WriteLine("(2) Varolan Numarayı Silmek");
                Console.WriteLine("(3) Varolan Numarayı Güncelleme");
                Console.WriteLine("(4) Rehberi Listelemek");
                Console.WriteLine("(5) Rehberde Arama Yapmak");
                Console.WriteLine("(6) Çıkış");
                
                
                Console.Write("Choice: ");
                string choice = Console.ReadLine();
                
                if(choice=="1")
                {
                    Console.Write("Lütfen isim giriniz             :");
                    string name = Console.ReadLine();
                    Console.Write("Lütfen soyisim giriniz          :");
                    string surname = Console.ReadLine();
                    Console.Write("Lütfen telefon numarası giriniz :");
                    string number = Console.ReadLine();

                    contacts.add_contact(new Person(name,surname,number));
                }
                else if(choice=="2")
                {
                    while(true)
                    {
                        Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
                        string remove_parameter = Console.ReadLine();

                        if(contacts.check_contact(remove_parameter) == true)
                        {
                            Console.WriteLine("{0} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)",remove_parameter);
                            string choice_y_n = Console.ReadLine();
                            
                            if(choice_y_n=="y")
                            {
                                contacts.remove_contact(remove_parameter);

                                break;
                                
                            }
                            else if(choice_y_n=="n")
                            {
                                break;
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                            Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                            Console.WriteLine("* Yeniden denemek için      : (2)");

                            string choice_remove = Console.ReadLine();

                            if (choice_remove=="1")
                            {
                                break;
                            }
                            else if(choice_remove=="2")
                            {
                                choice="2";
                            }
                            else
                            {
                                Console.WriteLine("Lütfen 1 veya 2 değerlerini giriniz!!!");
                                choice_remove="1";
                            }
                        }
                    }
                }
                else if(choice=="3")
                {
                    while(true)
                    {
                        Console.Write("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz:");
                        string update_person = Console.ReadLine();

                        if(contacts.check_contact(update_person)==true)
                        {
                            Console.Write("Lütfen yeni numarayı girin:");
                            string new_number = Console.ReadLine();
                            
                            contacts.update_contact(update_person,new_number);

                            break;
                        }
                        else
                        {
                            Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                            Console.WriteLine("* Güncellemeyi sonlandırmak için : (1)");
                            Console.WriteLine("* Yeniden denemek için           : (2)");

                            string choice_update = Console.ReadLine();

                            if (choice_update=="1")
                            {
                                break;
                            }
                            else if(choice_update=="2")
                            {
                                choice="3";
                            }
                            else
                            {
                                Console.WriteLine("Lütfen 1 veya 2 değerlerini giriniz!!!");
                                choice_update="1";
                            }
                        }
                    }
                }
                else if(choice=="4")
                {
                    Console.WriteLine("* A-Z  : (1)");
                    Console.WriteLine("* Z-A  : (2)");
                    string sort_parameter = Console.ReadLine();

                    contacts.view_contacts(sort_parameter);
                    
                }
                else if(choice=="5")
                {
                    while(true)
                    {
                        Console.Write("Lütfen aramak istediğiniz kişinin adını veya soyadını ya da numarasını giriniz:");
                        string find_parameter = Console.ReadLine();

                        if(contacts.check_contact(find_parameter))
                        {
                            contacts.find_contacts(find_parameter);

                            break;
                        }
                        else
                        {
                            Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                            Console.WriteLine("* Aramayı sonlandırmak için      : (1)");
                            Console.WriteLine("* Yeniden denemek için           : (2)");

                            string choice_find = Console.ReadLine();

                            

                            if(choice_find=="1")
                            {
                                break;
                            }
                            else if(choice_find=="2")
                            {
                                choice="5";
                            }
                            else
                            {
                                Console.WriteLine("Lütfen 1 veya 2 değerlerini giriniz!!!");
                                choice_find="5";
                            }
                        }
                    }      
                }
                else if(choice=="6")
                {
                    break;
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Lütfen 1 ve 6 arasında bir değer giriniz!!!");
                    Console.WriteLine(" ");
                }
            }
        }
    }
    class Person
    {
        public string name;
        public string surname;
        public string number;

        public Person(string name,string surname,string number)
        {
            this.name = name;
            this.surname = surname; 
            this.number = number;
        }

        public Person(){}
    }
    class Contacts
    {
        List<Person> contacts = new List<Person>();
        
        public void add_contact(Person person)
        {
            contacts.Add(person);
        }
        public void remove_contact(string remove_parameter)
        {
            int index = 0;

            foreach (var person in contacts)
            {
                if(person.name == remove_parameter || person.surname == remove_parameter || person.number == remove_parameter)
                {
                   index = contacts.IndexOf(person);
                }   
            }
            contacts.RemoveAt(index);
        }
        public void update_contact(string update_person,string new_number)
        {
            foreach (var person in contacts)
            {
                if(person.name == update_person || person.surname == update_person || person.number == update_person)
                {
                  person.number = new_number;
                  break;
                }   
            }
        }
        public void view_contacts(string sort_parameter)
        {   
            List<Person> sorted_list = contacts.OrderBy(o=>o.name).ToList();

            if(sort_parameter=="1")
            {
                foreach(var person in sorted_list)
                {
                    Console.WriteLine("Name: {0}",person.name);
                    Console.WriteLine("Surname: {0}",person.surname);
                    Console.WriteLine("Number: {0}",person.number);
                    Console.WriteLine("-");
                }
            }
            else
            {
                sorted_list.Reverse();

                foreach(var person in sorted_list)
                {
                    Console.WriteLine("Name: {0}",person.name);
                    Console.WriteLine("Surname: {0}",person.surname);
                    Console.WriteLine("Number: {0}",person.number);
                    Console.WriteLine("-");
                }
            }
        }
        public void find_contacts(string find_parameter)
        {
            foreach (var person in contacts)
            {
                if(person.name == find_parameter || person.surname == find_parameter || person.number == find_parameter)
                {
                    Console.WriteLine("Name: {0}",person.name);
                    Console.WriteLine("Surname: {0}",person.surname);
                    Console.WriteLine("Number: {0}",person.number);
                    Console.WriteLine("-");
                }   
            }
        }
        public bool check_contact(string find_parameter)
        {
            bool check = false;
            
            foreach (var person in contacts)
            {
                if(person.name == find_parameter || person.surname == find_parameter || person.number == find_parameter)
                {
                   check = true;
                }   
            }
            return check;
        }
    }
}   