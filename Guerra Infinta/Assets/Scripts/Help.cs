using System.Linq;
using UnityEngine;


public interface IAtaque
{
    void Atacar();
}

public class AtaqueFogo : IAtaque
{
    public void Atacar()
    {
        Debug.Log("Inimigo ataca com fogo!");
    }
}

public class AtaqueGelo : IAtaque
{
    public void Atacar()
    {
        Debug.Log("Inimigo ataca com gelo!");
    }
}

public class Inimigo : MonoBehaviour
{
    private IAtaque ataque;

    public void DefinirAtaque(IAtaque novoAtaque)
    {
        ataque = novoAtaque;
    }

    public void Atacar()
    {
        ataque?.Atacar();
    }
}

public class Controlador : MonoBehaviour
{
    private Inimigo inimigo;

    void Start()
    {
        inimigo = GetComponent<Inimigo>();

        // Trocar para AtaqueFogo
        IAtaque ataqueFogo = new AtaqueFogo();
        inimigo.DefinirAtaque(ataqueFogo);
        inimigo.Atacar();

        // Trocar para AtaqueGelo
        IAtaque ataqueGelo = new AtaqueGelo();
        inimigo.DefinirAtaque(ataqueGelo);
        inimigo.Atacar();
    }
}

//----------------------------------------------------------------------------------------------------------------------------------------------------------------

//1. S – Single Responsibility Principle (SRP)

public class Inimigo1 : MonoBehaviour
{
    private MovimentoInimigo movimento;
    private AtaqueInimigo ataque1;

    private void Start()
    {
        movimento = GetComponent<MovimentoInimigo>();
        ataque1 = GetComponent<AtaqueInimigo>();
    }
}

public class MovimentoInimigo : MonoBehaviour
{
    public void Mover()
    {
        Debug.Log("Inimigo se movendo...");
    }
}

public class AtaqueInimigo : MonoBehaviour
{
    public void Atacar()
    {
        Debug.Log("Inimigo atacando...");
    }
}


//----------------------------------------------------------------------------------------------------------------------------------------------------------------

//4. I – Interface Segregation Principle (ISP)

public interface IMovivel
{
    void Mover();
}

public interface IVoador
{
    void Voar();
}

public class InimigoTerrestre : IMovivel
{
    public void Mover()
    {
        Debug.Log("Inimigo terrestre se movendo!");
    }
}

public class InimigoVoador : IMovivel, IVoador
{
    public void Mover()
    {
        Debug.Log("Inimigo voador se movendo!");
    }

    public void Voar()
    {
        Debug.Log("Inimigo voando!");
    }
}


//----------------------------------------------------------------------------------------------------------------------------------------------------------------

// Todos os scripts implementam IAtaque

//public class AtaqueFogo : MonoBehaviour, IAtaque { ... }
//public class AtaqueGelo : MonoBehaviour, IAtaque { ... }

// Em algum gerenciador:
//public class TesteAtaque: MonoBehaviour { 
//    public void AtacarTodos()
//    {
//        //nome do tipo que virá lista //nome da lista = //pegar todos os ataques e colocar na lista
//        IAtaque[] ataques = FindObjectsOfType<MonoBehaviour>().OfType<IAtaque>().ToArray();

//        foreach (var ataque in ataques)
//        {
//            ataque.Atacar();
//        }
//    }
//}


//-------------------------------------------------------------------------------------------
//Exemplo de Interface e troca de ataque

//public class AttackNormal : IAttack
//{
//    public void Attack(Unit attacker, Unit target)
//    {
//        // Comportamento do ataque normal
//    }
//}

//public class MagicAttack : IAttack
//{
//    public void Attack(Unit attacker, Unit target)
//    {
//        // Comportamento do ataque mágico
//    }
//}

//public class RangedAttack : IAttack
//{
//    public void Attack(Unit attacker, Unit target)
//    {
//        // Comportamento do ataque à distância
//    }
//}

//private IAttack attackStrategy;

//void Start()
//{
//    attackStrategy = new AttackNormal();  // Inicia com ataque normal
//}

//public void ChangeToMagicAttack()
//{
//    attackStrategy = new MagicAttack();  // Muda para o ataque mágico
//}

//public void ChangeToRangedAttack()
//{
//    attackStrategy = new RangedAttack();  // Muda para o ataque à distância
//}

//public void Attack(Unit target)
//{
//    attackStrategy.Attack(this, target);  // Executa o ataque com o tipo atual de ataque
//}