namespace druida.dotnet.shared.secrets.hashicorpvault;

public record VaultSettings
{
    public string? VaultUrl { get; private set; }
    public string? TokenApi { get; init; }

    public void UpdateUrl(string url)
    {
        VaultUrl = url;
    }
}