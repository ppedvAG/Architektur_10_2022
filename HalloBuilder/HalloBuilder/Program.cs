using HalloBuilder;
using System.Text;

Console.WriteLine("Hello Builder");

var schrank1 = new Schrank.Builder()
                          .SetTüren(7)
                          .SetBöden(4)
                          .SetOberfläche(Oberfläche.Lackiert)
                          .SetFarbe("Gelb")
                          .Create();


var schrank2 = new Schrank.Builder()
                          .SetTüren(2)
                          .SetBöden(4)
                          .SetOberfläche(Oberfläche.Lackiert)
                          .SetFarbe("Gelb")
                          .Create();

StringBuilder sb = new StringBuilder();
sb.AppendLine("Hallo");
sb.AppendLine("Welt");
Console.WriteLine(sb.ToString());