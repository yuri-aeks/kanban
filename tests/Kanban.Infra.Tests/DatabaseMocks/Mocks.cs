namespace Kanban.Infra.Tests.DatabaseMocks;

public static class Mocks
{
    public static string SampleMockOne = "{\"Id\":\"65c6e255a03db52a8056230f\",\"Name\":\"Card Test One\", \"Description\":\"Card One Description\"}";
    public static string SampleMockTwo = "{\"Id\":\"65c77ba67d5a911ae3d662db\",\"Name\":\"Card Test Two\", \"Description\":\"Card Two Description\"}";
    public static string SampleMockThree = "{\"Id\":\"65c77bbb7d5a911ae3d662dc\",\"Name\":\"Card Test Three\", \"Description\":\"Card Three Description\"}";

    public static string InsertMockObject = "{\"Id\":\"65c782127d5a911ae3d662dd\",\"Name\":\"Card Test Insert\", \"Description\":\"Card Insert Description\"}";

    public static string UpdateMockObject = "{\"Id\":\"65c89bcd3adb8be079b61e88\",\"Name\":\"Card Test Update\", \"Description\":\"Card Update Description\"}";

    public static string NonexistingMockObject = "{\"Id\":\"65c806377d5a911ae3d662f0\",\"Name\":\"Card Test Update\", \"Description\":\"Card Update Description\"}";

    public static string SampleMockOneId = "65c6e255a03db52a8056230f";
    public static string SampleMockTwoId = "65c77ba67d5a911ae3d662db";
    public static string NonExistingCardId = "65c7c4ea7d5a911ae3d662e4";

    public static string ClientMock = "{\"Id\":\"client\", \"secret\":\"secret\"}";
    public static string NewClientMock = "{\"Id\":\"newclient\", \"secret\":\"newsecret\"}";
}
