function problem_part1(input_vector)
    total_sum = 0
    mul_string = ""
    left_number = ""
    right_number = ""
    comma_exists = false
    for line in input_vector
        mul_string = ""
        left_number = ""
        right_number = ""
        comma_exists = false
        for char in line
            if !isdigit(char) && !(char in ['m', 'u', 'l', '(', ')', ','])
                mul_string = ""
                left_number = ""
                right_number = ""
                comma_exists = false
                continue
            end

            if char == 'm'
                if mul_string == ""
                    mul_string *= char
                else
                    mul_string = ""
                end
                continue
            end

            if char == 'u'
                if mul_string == "m"
                    mul_string *= char
                else
                    mul_string = ""
                end
                continue
            end

            if char == 'l'
                if mul_string == "mu"
                    mul_string *= char
                else
                    mul_string = ""
                end
                continue
            end

            if char == '('
                if mul_string == "mul"
                    mul_string *= char
                else
                    mul_string = ""
                end
                continue
            end

            if mul_string == "mul("
                if char == ')'
                    if all(isdigit, left_number) && all(isdigit, right_number)
                        total_sum += parse(Int, left_number) * parse(Int, right_number)
                    end
                    mul_string = ""
                    left_number = ""
                    right_number = ""
                    comma_exists = false
                    continue
                end

                if char == ','
                    if all(isdigit, left_number)
                        comma_exists = true
                    else
                        mul_string = ""
                        left_number = ""
                        right_number = ""
                        comma_exists = false
                    end
                    continue
                end

                if isdigit(char)
                    if comma_exists
                        # right number
                        if length(right_number) < 3
                            right_number *= char
                        end
                    else
                        # left number
                        if length(left_number) < 3
                            left_number *= char
                        end
                    end
                else
                    mul_string = ""
                    left_number = ""
                    right_number = ""
                    comma_exists = false
                end
                continue
            end
        end
    end

    return total_sum
end

function problem_part2(input_vector)
    total_sum = 0
    mul_string = ""
    left_number = ""
    right_number = ""
    comma_exists = false
    do_or_dont_string = ""
    do_flag = true
    prev_char = Nothing
    for line in input_vector
        mul_string = ""
        left_number = ""
        right_number = ""
        comma_exists = false
        for char in line
            if char == 'd'
                if do_or_dont_string == "" && prev_char == Nothing
                    do_or_dont_string *= char
                    prev_char = char
                else
                    do_or_dont_string = ""
                    prev_char = Nothing
                end
            elseif char == 'o'
                if do_or_dont_string == "d" && prev_char == 'd'
                    do_or_dont_string *= char
                    prev_char = char
                else
                    do_or_dont_string = ""
                    prev_char = Nothing
                end
            elseif char == 'n'
                if do_or_dont_string == "do" && prev_char == 'o'
                    do_or_dont_string *= char
                    prev_char = char
                else
                    do_or_dont_string = ""
                    prev_char = Nothing
                end
            elseif char == '''
                if do_or_dont_string == "don" && prev_char == 'n'
                    do_or_dont_string *= char
                    prev_char = char
                else
                    do_or_dont_string = ""
                    prev_char = Nothing
                end
            elseif char == 't'
                if do_or_dont_string == "don'" && prev_char == '''
                    do_or_dont_string *= char
                    prev_char = char
                else
                    do_or_dont_string = ""
                    prev_char = Nothing
                end
            elseif char == '('
                if do_or_dont_string == "don't" && prev_char == 't'
                    do_or_dont_string *= char
                    prev_char = char
                elseif do_or_dont_string == "do" && prev_char == 'o'
                    do_or_dont_string *= char
                    prev_char = char
                else
                    do_or_dont_string = ""
                    prev_char = Nothing
                end
            elseif char == ')'
                if do_or_dont_string == "don't(" && prev_char == '('
                    do_or_dont_string *= char
                    prev_char = char
                elseif do_or_dont_string == "do(" && prev_char == '('
                    do_or_dont_string *= char
                    prev_char = char
                else
                    do_or_dont_string = ""
                    prev_char = Nothing
                end
            else
                do_or_dont_string = ""
                prev_char = Nothing
            end

            if do_or_dont_string == "don't()"
                do_flag = false
                do_or_dont_string = ""
                prev_char = Nothing
            end

            if do_or_dont_string == "do()"
                do_flag = true
                do_or_dont_string = ""
                prev_char = Nothing
            end

            if !do_flag
                continue
            end

            if do_flag
                if !isdigit(char) && !(char in ['m', 'u', 'l', '(', ')', ','])
                    mul_string = ""
                    left_number = ""
                    right_number = ""
                    comma_exists = false
                    continue
                end
                if char == 'm'
                    if mul_string == ""
                        mul_string *= char
                    else
                        mul_string = ""
                    end
                    continue
                end
                if char == 'u'
                    if mul_string == "m"
                        mul_string *= char
                    else
                        mul_string = ""
                    end
                    continue
                end
                if char == 'l'
                    if mul_string == "mu"
                        mul_string *= char
                    else
                        mul_string = ""
                    end
                    continue
                end
                if char == '('
                    if mul_string == "mul"
                        mul_string *= char
                    else
                        mul_string = ""
                    end
                    continue
                end

                if mul_string == "mul("
                    if char == ')'
                        if all(isdigit, left_number) && all(isdigit, right_number)
                            total_sum += parse(Int, left_number) * parse(Int, right_number)
                        end
                        mul_string = ""
                        left_number = ""
                        right_number = ""
                        comma_exists = false
                        continue
                    end

                    if char == ','
                        if all(isdigit, left_number)
                            comma_exists = true
                        else
                            mul_string = ""
                            left_number = ""
                            right_number = ""
                            comma_exists = false
                        end
                        continue
                    end

                    if isdigit(char)
                        if comma_exists
                            # right number
                            if length(right_number) < 3
                                right_number *= char
                            end
                        else
                            # left number
                            if length(left_number) < 3
                                left_number *= char
                            end
                        end
                    else
                        mul_string = ""
                        left_number = ""
                        right_number = ""
                        comma_exists = false
                    end
                    continue
                end
            end
        end
    end

    return total_sum
end