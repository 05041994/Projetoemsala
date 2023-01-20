using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace EscolaApp
{
    static class NProfessor
    {
        private static List<Professor> Profs = new List<Professor>();

        public static void Inserir(Professor p)
        {
            Abrir();
            
            int id = 0;
            foreach (Professor obj in Profs)
                if (obj.Id > id) id = obj.Id;
            p.Id = id + 1;
            Profs.Add(p);
            Salvar();
        }
        public static List<Professor> Listar()
        {
            Abrir();
            return Profs;
        }
        public static void Atualizar(Professor p)
        {
            Abrir();
            
            foreach (Professor obj in Profs)
                if (obj.Id == p.Id)
                {
                    obj.Nome = p.Nome;
                    obj.Matricula = p.Matricula;
                    obj.Area = p.Area;
                    obj.Id = p.Id;
                    obj.Curso = p.Curso;
                }
            Salvar();
        }
        public static void Excluir(Professor p)
        {
            Abrir();
            
            Professor x = null;
            foreach (Professor obj in Profs)
                if (obj.Id == p.Id) x = obj;
            if (x != null) Profs.Remove(x);
            Salvar();
        }
        public static void Abrir()
        {
            StreamReader f = null;
            try
            {
               
                XmlSerializer xml = new XmlSerializer(typeof(List<Professor>));
                
                f = new StreamReader("./Profs.xml");
                
                Profs = (List<Professor>)xml.Deserialize(f);
            }
            catch
            {
                Profs = new List<Professor>();
            }
           
            if (f != null) f.Close();
        }
        public static void Salvar()
        {
         
            XmlSerializer xml = new XmlSerializer(typeof(List<Professor>));
            
            StreamWriter f = new StreamWriter("./Profs.xml", false);
            
            xml.Serialize(f, Profs);
            
            f.Close();
        }
        public static void Matricular(Professor a, Turma t)
        {
            a.Curso = t.Id;
            Atualizar(a);
        }
        public static List<Professor> Listar(Turma t)
        {
            Abrir();
            
            List<Professor> diario = new List<Professor>();
            foreach (Professor obj in Profs)
                if (obj.Id == t.Id) diario.Add(obj);
            return diario;
        }

    }
}
