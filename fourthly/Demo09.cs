using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace fourthlySeason
{
    public class Student2
    {
        public Student2()
        {
        }
        public Student2(long id, string name, int age, int gender, string address)
        {
            Id = id;
            Name = name;
            Age = age;
            Gender = gender;
            Address = address;
        }


        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        public override string? ToString()
        {
            return $"{{ID: {Id}, Name: {Name}, Age: {Age}, Gender: {Gender}, Address: {Address} }}";
        }
    }

    public class Student3
    {
        public Student3() { }
        public string school { set; get; }

        public Student2[] studentList { set; get; }

        public override string? ToString()
        {
            string studentListString = string.Join(", ", studentList.Select(s => s.ToString()));
            return $"{{ school: {school}, sutentList: [{ studentListString}] }}";
        }
    }

    internal class Demo09
    {

        /// <summary>
        /// XML解析
        /// </summary>
        public List<Student2> Test01()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("D:/eatMeal/CSharp/CSharpProject/CSharpStudy/fourthly/file/student/studentTable.xml");
            //xmlDocument.LoadXml(File.ReadAllText("D:/eatMeal/CSharp/CSharpProject/CSharpStudy/fourthly/file/student/studentTable.xml"));
            List<Student2> student2List = new List<Student2>();

            // 获取第一个子节点(根节点), 如果xml中根节点就是多个平级的那可能有多个子节点, 但此处获取的是第一个, 相当于根节点
            // 实际上 xmlDocument.firstChild 获取的第一个子节点是 <?xml version="1.0" encoding="utf-8" ?> 我们的根节点 <studentTable>是第二个
            XmlNode rootNode = xmlDocument.ChildNodes[1];
            if(rootNode == null)
            {
                return student2List;
            }

            // 但是按照这种方式解析, 实际上是在已知xml文件的格式后解析的
            XmlNodeList xmlNodeList = rootNode.ChildNodes;
            foreach(XmlNode itemNode in xmlNodeList)
            {
                XmlNodeList fieldNodeList = itemNode.ChildNodes;
                Student2 student2 = new Student2();
                foreach (XmlNode fieldNode in fieldNodeList)
                {

                    // 这些if可以保证, <student>中的属性顺序不一致, 也可以正确读取
                    if(fieldNode.Name == "id")
                    {
                        student2.Id = Convert.ToInt64(fieldNode.InnerText);
                    }
                    else if(fieldNode.Name == "name")
                    {
                        student2.Name = fieldNode.InnerText;
                    }
                    else if(fieldNode.Name == "age")
                    {
                        student2.Age = Convert.ToInt32(fieldNode.InnerText);
                    }
                    else if(fieldNode.Name == "gender")
                    {
                        student2.Gender = Convert.ToInt32(fieldNode.InnerText);
                    }
                    else if(fieldNode.Name == "address")
                    {
                        student2.Address = fieldNode.InnerText;
                    }
                }

                student2List.Add(student2);
            }

            foreach(Student2 student2  in student2List)
            {
                Console.WriteLine(student2);
            }

            return student2List;
        }


        /// <summary>
        /// XML解析
        /// </summary>
        public List<Student2> Test02()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(File.ReadAllText("D:/eatMeal/CSharp/CSharpProject/CSharpStudy/fourthly/file/student/studentTable.xml"));
            List<Student2> student2List = new List<Student2>();

            XmlNode rootNode = xmlDocument.ChildNodes[1];// <studentTable>
            if (rootNode == null)
            {
                return student2List;
            }

            XmlNodeList xmlNodeList = rootNode.ChildNodes;// <student>
            foreach (XmlNode itemNode in xmlNodeList)
            {
                Student2 student2 = new Student2();

                XmlElement? idElement = itemNode["id"];// <id>
                XmlElement? nameElement = itemNode["name"];// 通过索引器的方式获取 itemNode下面的子节点
                XmlElement? ageElement = itemNode["age"];
                XmlElement? genderElement = itemNode["gender"];
                XmlElement? addressElement = itemNode["address"];// <address>

                student2.Id = idElement != null ? Convert.ToInt64(idElement.InnerText) : -1;
                student2.Name = nameElement != null ? nameElement.InnerText : "";
                student2.Age = ageElement != null ? Convert.ToInt32(ageElement.InnerText) : -1;
                student2.Gender = genderElement != null ? Convert.ToInt32(genderElement.InnerText) : -1;
                student2.Address = addressElement != null ? addressElement.InnerText : "";

                student2List.Add(student2);
            }

            foreach (Student2 student2 in student2List)
            {
                Console.WriteLine(student2);
            }

            return student2List;
        }

        /// <summary>
        /// json 反序列化
        /// </summary>
        /// <returns></returns>
        public Student3 Test03()
        {
            string studentJson = File.ReadAllText("D:/eatMeal/CSharp/CSharpProject/CSharpStudy/fourthly/file/student/studentTable.json");
            Student3 student = JsonConvert.DeserializeObject<Student3>(studentJson);

            Console.WriteLine(student);

            return student;
        }

        /// <summary>
        /// json 序列化
        /// </summary>
        /// <returns></returns>
        public String Test04()
        {
            Student3 student = new Student3();
            student.school = "希望三小";
            student.studentList = new Student2[3];
            student.studentList[0] = new Student2(1, "小二", 6, 1, "希望三小二班");
            student.studentList[1] = new Student2(2, "小三", 7, 1, "希望三小二班");
            student.studentList[2] = new Student2(3, "小四", 6, 0, "希望三小三班");

            string studentJson = JsonConvert.SerializeObject(student);

            Console.WriteLine(studentJson);

            return studentJson;
        }
    }
}
