
public interface IHealth 
{
    void AddHealth(int amount);
    void ReduceHealth(int amount);
    int  GetHealthAmount();
    void SetHealthAmount(int amount);
    bool IsDie();
}
