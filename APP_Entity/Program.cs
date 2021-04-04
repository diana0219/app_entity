using APP_Entity.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APP_Entity
{
	class Program
	{
		static List<Estudiante> ListaEstudiantes = new List<Estudiante>();
		static Validaciones Validar = new Validaciones();

		static void Main(string[] args)

		{


			string opcion;
			int posicion;
			string temporal;
			bool EntValida = false;

			Console.Clear();
			do
			{

				opcion = Console.ReadLine();
				for (int i = 4; i < 100; i++)
				{

					Console.SetCursorPosition(i, 4); Console.Write("═");
					Console.SetCursorPosition(i, 8); Console.Write("═");
				}
				for (int i = 5; i <= 7; i++)
				{
					Console.SetCursorPosition(4, i); Console.WriteLine("║");
					Console.SetCursorPosition(99, i); Console.WriteLine("║");
				}



				Console.SetCursorPosition(10, 6); Console.WriteLine("1.Agregar");
				Console.SetCursorPosition(25, 6); Console.WriteLine("2.Listar");
				Console.SetCursorPosition(38, 6); Console.WriteLine("3.Buscar");
				Console.SetCursorPosition(50, 6); Console.WriteLine("4.Editar");
				Console.SetCursorPosition(65, 6); Console.WriteLine("5.Borrar");
				Console.SetCursorPosition(79, 6); Console.WriteLine("0.Salir");



				for (int i = 4; i < 100; i++)
				{
					Console.SetCursorPosition(i, 10); Console.Write("═");
					Console.SetCursorPosition(i, 26); Console.Write("═");
				}
				for (int i = 11; i <= 25; i++)
				{
					Console.SetCursorPosition(4, i); Console.WriteLine("║");
					Console.SetCursorPosition(99, i); Console.WriteLine("║");
				}

				Console.SetCursorPosition(38, 12); Console.WriteLine(" BIENVENIDOS");

				Console.SetCursorPosition(10, 15); Console.Write(" ▓▓▓▓▓ ▓▓▓▓▓▓ ▓▓     ▓   ▓▓▓  ");
				Console.SetCursorPosition(10, 16); Console.Write("▓      ▓      ▓ ▓    ▓  ▓   ▓ ");
				Console.SetCursorPosition(10, 17); Console.Write("▓      ▓      ▓  ▓   ▓ ▓     ▓");
				Console.SetCursorPosition(10, 18); Console.Write(" ▓▓▓▓  ▓▓▓▓▓  ▓   ▓  ▓ ▓▓▓▓▓▓▓");
				Console.SetCursorPosition(10, 19); Console.Write("     ▓ ▓      ▓    ▓ ▓ ▓     ▓");
				Console.SetCursorPosition(10, 20); Console.Write("     ▓ ▓      ▓     ▓▓ ▓     ▓");
				Console.SetCursorPosition(10, 21); Console.Write("▓▓▓▓▓  ▓▓▓▓▓▓ ▓      ▓ ▓     ▓");
				Console.SetCursorPosition(10, 23); Console.WriteLine("Centro de Gestión de Mercados, Logística y Tecnologías de la Información");
				posicion = int.Parse(Console.ReadLine());


				do
				{

					Console.SetCursorPosition(74, 5); Console.WriteLine("Digite una opcion [ ]");
					temporal = Console.ReadLine();
					if (!Validar.Vacio(temporal))
						if (Validar.TipoNumero(temporal))
							EntValida = true;

				} while (!EntValida);



				switch (posicion)
				{


					case 1:
						AgregarEstudiante();
						break;
					case 2:
						ListarEstudiantes();
						break;
					case 3:
						BuscarEstudiante();
						break;
					case 4:
						EditarEstudiante();
						break;
					case 5:
						BorrarEstudiante();
						break;

					case 0:
						Console.Clear();

						for (int i = 2; i < 100; i++)
						{
							Console.SetCursorPosition(i, 4); Console.Write("▄");
							Console.SetCursorPosition(i, 25); Console.Write("▄");
						}
						for (int i = 5; i <= 25; i++)
						{
							Console.SetCursorPosition(2, i); Console.WriteLine("▓");
							Console.SetCursorPosition(99, i); Console.WriteLine("▓");
						}

						Console.SetCursorPosition(32, 10); Console.WriteLine(" ******************************");
						Console.SetCursorPosition(32, 11); Console.WriteLine(" Gracias por usar el aplicativo");
						Console.SetCursorPosition(32, 12); Console.WriteLine(" ******************************");


						Console.SetCursorPosition(35, 21); Console.WriteLine("──────▄▀▄─────▄▀▄──────");
						Console.SetCursorPosition(35, 22); Console.WriteLine("─────▄█░░▀▀▀▀▀░░█▄─────");
						Console.SetCursorPosition(35, 23); Console.WriteLine("─▄▄──█░░░░░░░░░░░█──▄▄─");
						Console.SetCursorPosition(35, 24); Console.WriteLine("█▄▄█─█░░▀░░┬░░▀░░█─█▄▄█");

						Console.ReadKey();
						break;
				}

			} while (posicion != 0);




			static void AgregarEstudiante()

			{

				Console.Clear();
				var database = new tallersenaContext();


				string email, cod, nom;
				bool CodigoValido = false;
				bool NombreValido = false;
				bool CorreoValido = false;

				do
				{

					for (int i = 5; i < 100; i++)
					{
						Console.SetCursorPosition(i, 6); Console.Write("═");
						Console.SetCursorPosition(i, 26); Console.Write("═");
					}
					for (int i = 7; i <= 25; i++)
					{
						Console.SetCursorPosition(5, i); Console.WriteLine("║");
						Console.SetCursorPosition(99, i); Console.WriteLine("║");
					}
					Console.SetCursorPosition(32, 10); Console.Write(" Digite Codigo del Estudiante: ");
					cod = Console.ReadLine();
					if (!Validar.Vacio(cod))
						if (Validar.TipoNumero(cod))
							CodigoValido = true;
				} while (!CodigoValido);


				if (Existe(Convert.ToInt32(cod)))
					Console.WriteLine("El codigo " + cod + " Ya existe en el sistema");
				else
				{

					do
					{
						Console.SetCursorPosition(32, 11); Console.Write(" Digite nombre del Estudiante: ");
						nom = Console.ReadLine();
						if (!Validar.Vacio(nom))
							if (Validar.TipoTexto(nom))
								NombreValido = true;
					} while (!NombreValido);



					do
					{
						Console.SetCursorPosition(32, 12); Console.Write(" Digite correo del Estudiante: ");
						email = Console.ReadLine();
						if (!Validar.Vacio(email))
							if (Validar.emailValido(email))
								CorreoValido = true;

					} while (!CorreoValido);


					Console.SetCursorPosition(32, 13); Console.Write(" Digite la nota # 1 ");
					double not1 = double.Parse(Console.ReadLine());
					Console.SetCursorPosition(32, 14); Console.Write(" Digite la nota # 2 ");
					double not2 = double.Parse(Console.ReadLine());
					Console.SetCursorPosition(32, 15); Console.Write(" Digite la nota # 3 ");
					double not3 = double.Parse(Console.ReadLine());


					Estudiante nuevoEstudiante = new Estudiante();
					nuevoEstudiante.Codigo = Convert.ToInt32(cod);
					nuevoEstudiante.Nombre = nom;
					nuevoEstudiante.Correo = email;
					nuevoEstudiante.Nota1 = not1;
					nuevoEstudiante.Nota2 = not2;
					nuevoEstudiante.Nota3 = not3;

					Console.WriteLine(nuevoEstudiante.Nombre);

					database.Estudiante.Add(nuevoEstudiante);
					database.SaveChanges();

					ListaEstudiantes.Add(nuevoEstudiante);
					Console.Clear();
				}

			}

			static void ListarEstudiantes()
			{
				Console.Clear();

				var database = new tallersenaContext();

				var ListaEstudiantes = database.Estudiante.ToList();
				int y = 10;
				for (int i = 5; i < 110; i++)
				{
					Console.SetCursorPosition(i, 6); Console.Write("═");
					Console.SetCursorPosition(i, 28); Console.Write("═");
				}
				for (int i = 7; i <= 27; i++)
				{
					Console.SetCursorPosition(5, i); Console.WriteLine("║");
					Console.SetCursorPosition(109, i); Console.WriteLine("║");
				}

				foreach (var myEstudiante in ListaEstudiantes)
				{
					y++;
					Console.SetCursorPosition(7, y); Console.Write("Cod: " + myEstudiante.Codigo);
					Console.SetCursorPosition(17, y); Console.Write("Nombre " + myEstudiante.Nombre);
					Console.SetCursorPosition(40, y); Console.Write("email " + myEstudiante.Correo);
					Console.SetCursorPosition(70, y); Console.Write("Nota 1: " + myEstudiante.Nota1);
					Console.SetCursorPosition(83, y); Console.Write("Nota 2: " + myEstudiante.Nota2);
					Console.SetCursorPosition(95, y); Console.Write("Nota 3: " + myEstudiante.Nota3);

				}
				Console.Write("\t");

				Console.SetCursorPosition(12, 29); Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
				Console.SetCursorPosition(12, 30); Console.WriteLine("║ ███▓▒░░Si desea volver al menu principal, oprima cualquier tecla░░▒▓███  ║");
				Console.SetCursorPosition(12, 31); Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");


				Console.ReadKey();
				Console.Clear();
			}
		}




		static void BuscarEstudiante()
		{

			string cod;

			var database = new tallersenaContext();

			Console.Clear();
			
			for (int i = 5; i < 110; i++)
			{
				Console.SetCursorPosition(i, 6); Console.Write("═");
				Console.SetCursorPosition(i, 28); Console.Write("═");
			}
			for (int i = 7; i <= 27; i++)
			{
				Console.SetCursorPosition(5, i); Console.WriteLine("║");
				Console.SetCursorPosition(109, i); Console.WriteLine("║");

			}

			Console.SetCursorPosition(10, 10); Console.WriteLine(" Buscar Estudiantes ");
			Console.SetCursorPosition(10, 12); Console.Write(" Digite Codigo del Estudiantes que desea buscar: ");
			cod = Console.ReadLine();

			if (Existe(Convert.ToInt32(cod)))

			{
				Estudiante myEstudiante = database.Estudiante.Find(Convert.ToInt32(cod));


				Console.SetCursorPosition(10, 15); Console.Write("codigo : " + myEstudiante.Codigo);
				Console.SetCursorPosition(10, 16); Console.Write("nombre : " + myEstudiante.Nombre);
				Console.SetCursorPosition(10, 17); Console.Write("correo : " + myEstudiante.Correo);
				Console.SetCursorPosition(10, 18); Console.Write("Nota 1 : " + myEstudiante.Nota1);
				Console.SetCursorPosition(10, 19); Console.Write("Nota 2 : " + myEstudiante.Nota2);
				Console.SetCursorPosition(10, 20); Console.Write("Nota 3 : " + myEstudiante.Nota3);

			}
			else
			{
				
				Console.SetCursorPosition(12, 20); Console.WriteLine("╔═════════════════════════════════════════════╗");
				Console.SetCursorPosition(12, 21); Console.WriteLine("║  El Usuario " + cod + " NO  existe en el sistema      ║");
				Console.SetCursorPosition(12, 22); Console.WriteLine("╚═════════════════════════════════════════════╝");
			}
			Console.SetCursorPosition(15, 29); Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
			Console.SetCursorPosition(15, 30); Console.WriteLine("║ ███▓▒░░Si desea volver al menu principal, oprima cualquier tecla░░▒▓███  ║");
			Console.SetCursorPosition(15, 31); Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");
			Console.ReadKey();
			Console.Clear();
		}

		static void EditarEstudiante()
		{
			var database = new tallersenaContext();

			bool NombreValido = false;
			bool CorreoValido = false;
			bool EntValida = false;

			string nom, email, cod;
			string atributoAEditar;

			Console.Clear();

			for (int i = 5; i < 110; i++)
			{
				Console.SetCursorPosition(i, 6); Console.Write("═");
				Console.SetCursorPosition(i, 26); Console.Write("═");
			}
			for (int i = 7; i <= 25; i++)
			{
				Console.SetCursorPosition(5, i); Console.WriteLine("║");
				Console.SetCursorPosition(109, i); Console.WriteLine("║");
			}

			Console.SetCursorPosition(25, 7); Console.Write(" Digite Codigo del Estudiantes que desea editar: ");
			cod = Console.ReadLine();

			if (Existe(Convert.ToInt32(cod)))
			{
				Estudiante myEstudiante = database.Estudiante.Find(Convert.ToInt32(cod));
				Console.SetCursorPosition(7, 9); Console.WriteLine("Codigo: " + myEstudiante.Codigo + "\t Nombre: " + myEstudiante.Nombre + "\t Correo: " + myEstudiante.Correo + "\t Nota 1 : " + myEstudiante.Nota1 + "\t Nota 2 : " + myEstudiante.Nota2 + "\t Nota 3 : " + myEstudiante.Nota3);
				Console.SetCursorPosition(7, 11); Console.WriteLine("Escribe el atributo a editar: ");
				Console.SetCursorPosition(7, 12); Console.WriteLine("1. Nombre");
				Console.SetCursorPosition(7, 13); Console.WriteLine("2. Email");
				Console.SetCursorPosition(7, 14); Console.WriteLine("3. Nota 1");
				Console.SetCursorPosition(7, 15); Console.WriteLine("4. Nota 2");
				Console.SetCursorPosition(7, 16); Console.WriteLine("5. Nota 3");
				do
				{
					atributoAEditar = Console.ReadLine();
					if (!Validar.Vacio(atributoAEditar))
						if (Validar.TipoNumero(atributoAEditar))
							EntValida = true;
				} while (!EntValida);

				switch (Convert.ToInt32(atributoAEditar))
				{
					case 1:
						
						do
						{
							Console.SetCursorPosition(7, 18); Console.Write("Digite nuevo nombre del Estudiantes : ");
							nom = Console.ReadLine();
							if (!Validar.Vacio(nom))
								if (Validar.TipoTexto(nom))
									NombreValido = true;
							myEstudiante.Nombre = nom;
						} while (!NombreValido);
						break;
					case 2:
						do
						{
							Console.SetCursorPosition(7, 18); Console.Write("Digite nuevo correo del Estudiantes : ");
							email = Console.ReadLine();
							if (!Validar.Vacio(email))
								if (Validar.emailValido(email))
									CorreoValido = true;
							myEstudiante.Correo = email;
						} while (!CorreoValido);
							break;
						case 3:
						Console.SetCursorPosition(7, 18); Console.WriteLine("Digite la nueva nota: ");
						double not1 = double.Parse(Console.ReadLine());
						myEstudiante.Nota1 = not1;
						break;
						case 4:
						Console.SetCursorPosition(7, 18); Console.WriteLine("Digite la nueva nota: ");
						double not2 = double.Parse(Console.ReadLine());
						myEstudiante.Nota2 = not2;
						break;
						case 5:
						Console.SetCursorPosition(7, 18); Console.WriteLine("Digite la nueva nota: ");
						double not3 = double.Parse(Console.ReadLine());
						myEstudiante.Nota3 = not3;
						break;
				}
				database.Estudiante.Update(myEstudiante);
				database.SaveChanges();

				Console.SetCursorPosition(10, 29); Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
				Console.SetCursorPosition(10, 30); Console.WriteLine("║ ███▓▒░░Si desea volver al menu principal, oprima cualquier tecla░░▒▓███  ║");
				Console.SetCursorPosition(10, 31); Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");
				Console.ReadKey();
				Console.Clear();
			}
		}



		static void BorrarEstudiante()
		{
			string cod;
			var database = new tallersenaContext();

			Console.Clear();
			for (int i = 5; i < 100; i++)
			{
				Console.SetCursorPosition(i, 6); Console.Write("═");
				Console.SetCursorPosition(i, 28); Console.Write("═");
			}
			for (int i = 7; i <= 27; i++)
			{
				Console.SetCursorPosition(5, i); Console.WriteLine("║");
				Console.SetCursorPosition(99, i); Console.WriteLine("║");
			}



			Console.SetCursorPosition(17, 7); Console.Write(" Digite Codigo del Estudiantes que desea eliminar : ");
			cod = Console.ReadLine();

			if (Existe(Convert.ToInt32(cod)))
			{
				Estudiante myEstudiante = database.Estudiante.Find(Convert.ToInt32(cod));
				Console.SetCursorPosition(10, 15); Console.Write("codigo : " + myEstudiante.Codigo);
				Console.SetCursorPosition(10, 16); Console.Write("nombre : " + myEstudiante.Nombre);
				Console.SetCursorPosition(10, 17); Console.Write("correo : " + myEstudiante.Correo);
				Console.SetCursorPosition(10, 18); Console.Write("Nota 1 : " + myEstudiante.Nota1);
				Console.SetCursorPosition(10, 19); Console.Write("Nota 2 : " + myEstudiante.Nota2);
				Console.SetCursorPosition(10, 20); Console.Write("Nota 3 : " + myEstudiante.Nota3);
				Console.SetCursorPosition(10, 23); Console.Write("Esta seguro que desea eliminar el Estudiantes? S/N   :  ");
				string flag = Console.ReadLine();
				if (flag == "S" || flag == "s")
				{
					database.Estudiante.Remove(myEstudiante);
					database.SaveChanges();

				}
				else if (flag == "N" || flag == "n")
				{
					Console.SetCursorPosition(10, 25); Console.Write("Se ha cancelado la eliminación del Estudiante, oprima una tecla para volver ");
					Console.ReadKey();
					
				}
				else
				{
					Console.SetCursorPosition(4, 27); Console.Write("La opcion ingresada no es valida, oprima cualquier tecla para volver al menu principal ");
				}

			}
			else
			{
				Console.SetCursorPosition(20, 20); Console.WriteLine("╔═════════════════════════════════════════════╗");
				Console.SetCursorPosition(20, 21); Console.WriteLine("║  El Usuario " + cod + " NO  existe en el sistema     ║");
				Console.SetCursorPosition(20, 22); Console.WriteLine("╚═════════════════════════════════════════════╝");
			}
				Console.SetCursorPosition(10, 29); Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
				Console.SetCursorPosition(10, 30); Console.WriteLine("║ ███▓▒░░Si desea volver al menu principal, oprima cualquier tecla░░▒▓███  ║");
				Console.SetCursorPosition(10, 31); Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");
				Console.ReadKey();
				Console.Clear();
		}
		static bool Existe(int cod)
		{
			bool aux = false;
			var database = new tallersenaContext();
			var estudiantes = database.Estudiante.ToList();
			foreach (var myEstudiante in estudiantes)
			{
				if (myEstudiante.Codigo == cod)
					aux = true;
			}
			return aux;
		}
	}



}



		
	

