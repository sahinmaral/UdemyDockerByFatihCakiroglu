int i = 1;
while (i < 100000)
{
    Console.WriteLine($"Hello World {i}");
    i++;

    System.Threading.Thread.Sleep(1000);
}