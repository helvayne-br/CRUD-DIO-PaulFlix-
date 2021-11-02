using System;

namespace Paulflix
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("See Ya! Bye!!!");
			Console.ReadLine();
        }

        private static void ExcluirSerie()
		{
			Console.Write("Type the Serie ID: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Type the Serie ID: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Type the Serie ID: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Type the gender of content: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Type the title of Content: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Type the year of production: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Type a description about the content: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										Titulo: entradaTitulo,
										Ano: entradaAno,
										Descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void ListarSeries()
		{
			Console.WriteLine("List series.");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("None registered.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Insert new content");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Type the gender of content: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Type the title of Content: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Type the year of production: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Type a description about the content: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										Titulo: entradaTitulo,
										Ano: entradaAno,
										Descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("PaulFlix. Always the best Choice!");
			Console.WriteLine("Choose an option below:");

			Console.WriteLine("1- List series ");
			Console.WriteLine("2- Insert serie");
			Console.WriteLine("3- Refresh series ");
			Console.WriteLine("4- Delete series ");
			Console.WriteLine("5- View series");
			Console.WriteLine("C- Clear Screen");
			Console.WriteLine("X- Exit");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
