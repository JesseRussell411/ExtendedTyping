﻿# Author: Jesse Russell
# Summary: Generates the struct definitions for the Loose datatype, up to n type parameters.

# Parameters:
FILE_NAME = "Loose.cs"
NAMESPACE = "ExtendedTyping"
UTILS_NAME = "LooseUtils"
STRUCT_NAME = "Loose"
VALUE_TYPE = "dynamic"
VALUE_NAME = "v"
VALUE_AS_OBJECT_NAME = "o"
TYPE_PARAMETER_COUNT = 32
#


# Constants:
INDENT = "    "
#


# Prep VALUE_NAME. un-capitalize it.
VALUE_NAME = VALUE_NAME[0].lower() + VALUE_NAME[1:]
VALUE_AS_OBJECT_NAME = VALUE_AS_OBJECT_NAME[0].lower() + VALUE_AS_OBJECT_NAME[1:]


# Returns string representation of the parameter: enumerable, delimited my the delim parameter.
def to_delim_string(enumerable, delim=", "):
    s = ""
    first = True
    for item in enumerable:
        if not first:
            s = s + delim

        s = s + str(item)

        first = False

    return s


# Open output file.
output = open(FILE_NAME, "w")

# #=========================#
# | Begin code generation:  |
# | ----------------------  |
# #=========================#

# Note.
output.write("//This code was generated by LooseGenerate.py\n")

# Using directives:
output.write("using System;\n")
output.write("using System.Collections.Generic;\n")
#

# Namespace declaration.
output.write("namespace " + NAMESPACE + "\n{\n")


INTERFACE_NAME = "I" + STRUCT_NAME


types = []
# Main loop...
for i in range(1, TYPE_PARAMETER_COUNT + 1):
    # Increment the last type parameter.
    types.append("T" + str(i))

    # Just to make things easier to read:
        # FullName...
    def full_name():
        return STRUCT_NAME + "<" + to_delim_string(types) + ">"

    FULL_NAME = full_name()

        # tn...
    def t(j):
        return "t" + str(j)

        # Tn...
    def T(j):
        return "T" + str(j)
    #

    # Struct declaration:
    output.write("    public struct " + STRUCT_NAME + "<")

    output.write(to_delim_string(types))

    output.write("> : " + INTERFACE_NAME + "\n")
    output.write("    {\n")
    #

    # Implicit casts...
    for j in range(1, i + 1):
        output.write("        public static implicit operator " + FULL_NAME + "(")
        output.write(T(j) + " " + t(j) + ") => new " + FULL_NAME + "(" + t(j) + ");\n")

    # Explicit casts...
    for j in range(1, i + 1):
        output.write("        public static explicit operator " + T(j) + "(" + FULL_NAME + " self) => self.")
        output.write(VALUE_NAME.capitalize() + " is " + T(j) + " " + t(j) + " ? " + t(j) + " : ")

            # Invalid cast exception.
        output.write("throw new InvalidCastException(")
        output.write(UTILS_NAME + ".GenerateInvalidCastExceptionMessage(self.GetType(), typeof(" + T(j) + ")")
        output.write(", self." + VALUE_NAME.capitalize() + ".GetType()));\n")

    # Remaining members:
    # ------------------

    # Value field:
    output.write(
        "        /// <summary>\n" +
        "        /// The value stored in the current " + STRUCT_NAME + " type.\n" +
        "        /// </summary>\n")
    output.write("        public " + VALUE_TYPE + " " + VALUE_NAME.capitalize() + " { get; }\n")
    #

    # private Constructor.
    output.write("        private " + STRUCT_NAME + "(" + VALUE_TYPE + " " + VALUE_NAME + ") => " + VALUE_NAME.capitalize() + " = " + VALUE_NAME + ";\n")

    # Object Method Overrides:
    output.write("        public override string ToString() => " + VALUE_NAME.capitalize() + ".ToString();\n")
    output.write("        public override bool Equals(object obj) => " + VALUE_NAME.capitalize() + ".Equals(obj);\n")
    output.write("        public override int GetHashCode() => " + VALUE_NAME.capitalize() + ".GetHashCode();\n")
    #

    # Derived Properties:
        # Type:
    output.write(
        "        /// <summary>\n" +
        "        /// The type of the value stored in the current " + STRUCT_NAME + " type.\n" +
        "        /// </summary>\n")
    output.write("        public Type Type => " + VALUE_NAME.capitalize() + ".GetType();\n")
        #

        # O:
    output.write(
        "        /// <summary>\n" +
        "        /// The value stored in the current " + STRUCT_NAME + " type in the form of an object.\n" +
        "        /// </summary>\n")
    output.write("        public object " + VALUE_AS_OBJECT_NAME.capitalize() + " => " + VALUE_NAME.capitalize() + ";\n")
        #

        # WhiteList
    output.write(
        INDENT * 2 + "/// <summary>\n" +
        INDENT * 2 + "/// Returns a TypeArray containing all of the types that are allowed.\n" +
        INDENT * 2 + "/// </summary>\n"
    )
    output.write(INDENT * 2 + "public IEnumerable<Type> WhiteList => new TypeArray<" + to_delim_string(types) + ">();\n")
        #

        # WhiteListSet
    output.write(
        INDENT * 2 + "/// <summary>\n" +
        INDENT * 2 + "/// Returns a set containing all of the types that are allowed.\n" +
        INDENT * 2 + "/// </summary>\n"
    )
    output.write(INDENT * 2 + "public HashSet<Type> WhiteListSet => new HashSet<Type>(WhiteList);\n")
        #
    #

    # Operators
        # ==
    output.write("        public static bool operator ==(" + FULL_NAME + " left, " + FULL_NAME + " right) => left.")
    output.write(VALUE_NAME.capitalize() + ".Equals(right." + VALUE_NAME.capitalize() + ");\n")

        # !=
    output.write("        public static bool operator !=(" + FULL_NAME + " left, " + FULL_NAME + " right) => !left.")
    output.write(VALUE_NAME.capitalize() + ".Equals(right." + VALUE_NAME.capitalize() + ");\n")
    #

    # Close struct.
    output.write("    }\n")

# Close namespace.
output.write("}")

# *Code Generation finished.

# Close output file.
output.close()
