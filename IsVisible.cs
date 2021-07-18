// Actually detect if an object is visible since unity's IsVisisble doesn't bother with detetecting obstructions
// Important note: If you have two cams renderering from different points and one is facing away from the cube, it will still show that it can see the object since the object is visible by at least one camera and there is no obstructions from the camera to the object.
public bool IsVisible(Renderer Renderer, Transform trans)
{
    // Don't raycast if the cube isn't even in front of the camera
    if(Renderer.isVisible)
    {
        // Raycast to make sure nothing is obstructing
        if(Physics.Raycast(transform.position, (trans.position - transform.position).normalized, out RaycastHit hit, 200f))
        {
            return (hit.collider.transform == trans);
        }
        else
        {
            return false;
        }
    } 
    else 
    {
        return false;
    }
}
