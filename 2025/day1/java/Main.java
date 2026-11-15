import java.nio.file.Files;
import java.nio.file.Path;

public class Main {
    public static void main(String[] args) {
        String filePath = "input.txt";
        String[] input = readFile(filePath);

        int resultPart1 = new Problem().problemPart1(input);
        System.out.println("Result Part 1: " + resultPart1);

        int resultPart2 = new Problem().problemPart2(input);
        System.out.println("Result Part 2: " + resultPart2);
    }

    public static String[] readFile(String filePath) {
        Path path = Path.of(filePath);
        try {
            return Files.lines(path).toArray(String[]::new);
        } catch (Exception e) {
            e.printStackTrace();
            return new String[0];
        }
    }
}
