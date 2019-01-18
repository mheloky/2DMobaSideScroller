using TCPIPGame.Server.DomainObjects;

public interface APhysicalPlayer
{
    void SetActive(bool active);
    bool GetActive(bool active);
    float NetworkHorizontalAxis
    {
        get;
        set;
    }
    APlayer ThePlayer
    {
        get;
        set;
    }

}