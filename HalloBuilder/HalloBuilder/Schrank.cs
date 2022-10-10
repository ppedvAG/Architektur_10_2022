namespace HalloBuilder
{
    internal class Schrank
    {
        public int AnzTüren { get; private set; } = 5;
        public int AnzBöden { get; private set; } = 5;
        public string Farbe { get; private set; } = string.Empty;
        public Oberfläche Oberfläche { get; private set; } = Oberfläche.Natur;
        public bool Metallschienen { get; private set; } = false;
        public bool Kleiderstange { get; private set; } = false;

        private Schrank()
        { }

        internal class Builder
        {
            private readonly Schrank _schrank = new();

            public Builder SetTüren(int anzTüren)
            {
                if (anzTüren < 2 || anzTüren > 7)
                    throw new ArgumentException("Zuviele oder zu wenige Türen");

                _schrank.AnzTüren = anzTüren;

                return this;
            }

            public Builder SetBöden(int anzBöden)
            {
                if (anzBöden < 0 || anzBöden > 6)
                    throw new ArgumentException("Zuviele oder zu wenige Böden");

                _schrank.AnzBöden = anzBöden;

                return this;
            }

            public Builder SetFarbe(string farbe)
            {
                if (string.IsNullOrWhiteSpace(farbe))
                    throw new ArgumentException("Eine Farbe muss angegeben werden");
                if (_schrank.Oberfläche != Oberfläche.Lackiert)
                    throw new ArgumentException("Eine Farbe kann nur gewählt werden, wenn der Schrank lackiert wird");

                _schrank.Farbe = farbe;

                return this;
            }

            public Builder SetOberfläche(Oberfläche oberfläche)
            {
                _schrank.Oberfläche = oberfläche;

                return this;
            }

            public Schrank Create()
            {
                return _schrank;
            }
        }
    }

    enum Oberfläche
    {
        Natur,
        Gewachst,
        Lackiert
    }
}
