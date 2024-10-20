public class Order
{
    private RecipeSO _recipe;

    public Order(RecipeSO recipe)
    {
        _recipe = recipe;
    }

    public RecipeSO RecipeSO 
    { 
        get 
        { 
            return _recipe; 
        } 
    }
}
