
public interface IHealth 
{
    void AddHealth(int amount);
    void ReduceHealth(int amount);
    int  GetCurrentHealthAmount();
    void SetHealthAmount(int amount);
    bool IsDie();
}
