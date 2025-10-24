using System.Collections;

public interface IDamageable
{
    IEnumerator TakeDamage(int damage, string sfx);
}