using ListaDeCompras.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListaDeCompras.Storage
{
    
    public interface IKeyObject
    {
        string Key { get; set; }
    }
        
    public class DatabaseManager
    {
        SQLiteConnection database;

        public DatabaseManager() {
            //Definição do Banco de dados utilizando DependencyService, pois cada Plataforma exige uma implementação 
            database = DependencyService.Get<ISQLite>().GetConnection();
            //criando a tabela do Tipo Item
            database.CreateTable<Item>();
        }


        //Método para salvar o Objeto
        public void SaveValue<T>(T value) where T : IKeyObject, new() {
            var all = (from entry in database.Table<T>().AsEnumerable<T>()
                       where entry.Key == value.Key
                       select entry).ToList();
            if (all.Count == 0)
                database.Insert(value);
            else
                database.Update(value);
        }

        //Metodo para deletar o Objeto
        public void DeleteValue<T>(T value) where T : IKeyObject, new()
        {
            var all = (from entry in database.Table<T>().AsEnumerable<T>()
                       where entry.Key == value.Key
                       select entry).ToList();
            if (all.Count == 1)
                database.Delete(value);
            else
                throw new Exception("O Banco de Dados não contém o valor especificado !");
        }


        //Método para obter todos os Objetos
        public List<TSource> GetAllItems<TSource>() where TSource : IKeyObject, new()
        {
            return database.Table<TSource>().AsEnumerable<TSource>().ToList();
        }

        
        //Método para obter um objeto a partir de uma chave
        public TSource GetItem <TSource>(string Key) where TSource : IKeyObject, new()
        {
            var result = (from entry in database.Table<TSource>().AsEnumerable<TSource>()
                       where entry.Key == Key
                       select entry).FirstOrDefault();       
            return result;
        }
    }
}
