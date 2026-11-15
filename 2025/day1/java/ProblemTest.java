import org.junit.Test;
import static org.junit.Assert.assertEquals;

public class ProblemTest {
    @Test
    public void testProblemPart1() {
        Problem problem = new Problem();
        String[] input = {
            "L68",
            "L30",
            "R48",
            "L5",
            "R60",
            "L55",
            "L1",
            "L99",
            "R14",
            "L82"
        };
        int result = problem.problemPart1(input);
        assertEquals(3, result);
    }

    @Test
    public void testProblemPart2() {
        Problem problem = new Problem();
        String[] input = {
            "L68",
            "L30",
            "R48",
            "L5",
            "R60",
            "L55",
            "L1",
            "L99",
            "R14",
            "L82"
        };
        int result = problem.problemPart2(input);
        assertEquals(6, result);
    }
}
