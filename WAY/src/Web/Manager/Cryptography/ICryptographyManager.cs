namespace Web.Manager {
	public interface ICryptographyManager {
		string Protect(string data);
		string Unprotect(string data);
	}
}
