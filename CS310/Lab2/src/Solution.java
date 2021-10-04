public class Solution {
	public static void main(String args[]) {
		System.out.println("Lower cases: " + lowerCount("Jack Young"));
		
		System.out.println("Lower cases: " + lowerCount("Jack Young", new char[] {'a', 'c'}));
	}
	
	public static int lowerCount(String input) {
		if (input.length() == 0) {
			return 0;
		}
		
		switch (input.charAt(0)) {
			case 'a':
				return 1 + lowerCount(input.substring(1));
			case 'e':
				return 1 + lowerCount(input.substring(1));
			case 'i':
				return 1 + lowerCount(input.substring(1));
			case 'o':
				return 1 + lowerCount(input.substring(1));
			case 'u':
				return 1 + lowerCount(input.substring(1));
			default:
				return lowerCount(input.substring(1));
		}
	}
	
	public static int lowerCount(String input, char[] letters) {
		if (input.length() == 0) {
			return 0;
		}
		
		for (char c : letters) {
			if (input.charAt(0) == c)
				return 1 + lowerCount(input.substring(1), letters);
		}
		return lowerCount(input.substring(1), letters);
	}
}