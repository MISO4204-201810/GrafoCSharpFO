using System;

namespace  FactoryMethod

{
    class MainApp
    {
        static void Main()
        {
            int userInput = 0;
            
            Configuracion configuracion = new Configuracion();
            userInput = configuracion.DisplayMenu();
            configuracion.ArmarConfiguracion(userInput);

            //CREACION DEL GRAFO
            CreadordeGrafo creadorGrafo;

            switch (configuracion.TipoGrafo)
            {
                case "Directed":
                    creadorGrafo = new CrearGrafoDirected();
                    break;
                case "Undirected":
                    creadorGrafo = new CrearGrafoIndirected();
                    break;
                default:
                    creadorGrafo = new CrearGrafoDirected();
                    break;
            }

            Grafo grafo = creadorGrafo.MetodoFabricacionGrafo();
            Console.WriteLine("Creado el tipo de Grafo {0}", grafo.GetType().Name);

            //SELECCION Y CALCULO DEL PESO SI VIENE EN LA CONFIGURACION
            if (configuracion.TipoPeso.Equals("Weighted"))
            {
                DecaradorConcretoCalcularPeso decoradorCalculoPeso = new DecaradorConcretoCalcularPeso();
                decoradorCalculoPeso.SetComponent(grafo);
                decoradorCalculoPeso.CalcularPeso();
            }
            else
            {
                Console.WriteLine("La configuracion no tiene un calculo de peso definido");
            }

            //SELECCION Y TIPO DE ESTRATEGIA SI VIENE EN LA CONFIGURACION
            ContextodeCalculo contextodeCalculo;

            switch (configuracion.TipoBusqueda)
            {
                case "BFS":
                    contextodeCalculo = new ContextodeCalculo(new EstrategiaBFS());
                    contextodeCalculo.InterfacedeContexto(grafo);
                    break;
                case "DFS":
                    contextodeCalculo = new ContextodeCalculo(new EstrategiaDFS());
                    contextodeCalculo.InterfacedeContexto(grafo);
                    break;
                default:
                    Console.WriteLine("La configuracion no tiene una estrategia de busqueda definida");
                    break;
            }

            Console.ReadKey();
        }

    }

    //CLASES DEL METODO DE FABRICA CONSTRUCCION GRAFO
    abstract class Grafo : ComponenteCalculoPeso
    {
    }

    class GrafoConcretoDirected : Grafo 
    {
        public override void CalcularPeso()
        {
            Console.WriteLine("\t\tSe realizo operacion base de Calculo de Peso en Grafo Dirigido");
        }
    }
    class GrafoConcretoIndirected : Grafo
    {
        public override void CalcularPeso()
        {
            Console.WriteLine("\t\tSe realizo operacion base de Calculo de Peso en Grafo No Dirigido");
        }
    }
    abstract class CreadordeGrafo
    {
        public abstract Grafo MetodoFabricacionGrafo();
    }
    class CrearGrafoDirected : CreadordeGrafo
    {
        public override Grafo MetodoFabricacionGrafo()
        {
            return new GrafoConcretoDirected();
        }
    }
    class CrearGrafoIndirected : CreadordeGrafo
    {
        public override Grafo MetodoFabricacionGrafo()
        {
            return new GrafoConcretoIndirected();
        }
    }

    // CLASES DEL DECORADOR PARA EL CALCULO DE PESO
    abstract class ComponenteCalculoPeso

    {
        public abstract void CalcularPeso();
    }
    class ComponenteConcreto : ComponenteCalculoPeso

    {
        public override void CalcularPeso()
        {
            Console.WriteLine("\t\tOperacion Indicada en el Componente de Calculo Concreto");
        }
    }
    abstract class Decorador : ComponenteCalculoPeso

    {
        protected ComponenteCalculoPeso componenteCalcularPeso;

        public void SetComponent(ComponenteCalculoPeso component)
        {
            this.componenteCalcularPeso = component;
        }

        public override void CalcularPeso()
        {
            if (componenteCalcularPeso != null)
            {
                componenteCalcularPeso.CalcularPeso();
            }
        }
    }
    class DecaradorConcretoCalcularPeso : Decorador

    {
        public override void CalcularPeso()
        {
            base.CalcularPeso();
            Console.WriteLine("\t\t Se realizo la operacion sobre el Decorador CalcularPeso()");
        }
    }

    // CLASES DE ESTRATEGIA PARA BUSQUEDA DEL ARBOL A LO ANCHO Y POR PROFUNDIDAD

    abstract class EstrategiadeCalculo

    {
        public abstract void AlgoritmodeCalculo(Grafo grafo);
    }
    class EstrategiaBFS : EstrategiadeCalculo

    {
        public override void AlgoritmodeCalculo(Grafo grafo)
        {
            Console.WriteLine(
              "Llamado a la EstrategiaBFS.AlgoritmodeCalculo()");
        }
    }
    class EstrategiaDFS : EstrategiadeCalculo

    {
        public override void AlgoritmodeCalculo(Grafo grafo)
        {
            Console.WriteLine(
              "Llamado a la EstrategiaDFS.AlgoritmodeCalculo()");
        }
    }
    class ContextodeCalculo

    {
        private EstrategiadeCalculo _Estrategia;

        public ContextodeCalculo(EstrategiadeCalculo estrategiadeCalculo)
        {
            this._Estrategia = estrategiadeCalculo;
        }

        public void InterfacedeContexto(Grafo grafo)
        {
            _Estrategia.AlgoritmodeCalculo(grafo);
        }
    }
}

