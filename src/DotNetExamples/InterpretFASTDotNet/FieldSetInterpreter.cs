﻿using System;
using System.Collections.Generic;
using System.Text;
using QuickFAST.DotNet;

namespace QuickFASTDotNet
{
    namespace Examples
    {
        public class FieldSetInterpreter
        {
            String indent_ = "";

            public void interpret(QuickFAST.DotNet.DNFieldSet fieldSet)
            {
                formatFieldSet(fieldSet);
            }

            public void formatFieldSet(QuickFAST.DotNet.DNFieldSet fieldSet)
            {
                uint size = fieldSet.size();
                //Console.WriteLine("{0}fields: {1}", indent_, size);
                for (uint nField = 0; nField < size; ++nField)
                {
                    DNField field = fieldSet.getField(nField);
                    FieldType type = field.type();
                    if (type == FieldType.SEQUENCE)
                    {
                        formatSequence(field);
                    }
                    else if (type == FieldType.GROUP)
                    {
                        Console.WriteLine("{0}Group {1}:", indent_, field.localName());
                        formatGroup(field);
                    }
                    else
                    {
                        Console.Write(" {0}[{1}]={2}",
                            field.localName(),
                            field.id(),
                            field.asString()
                            );
                    }
                }
            }

            public void formatSequence(DNField field)
            {
                DNSequence sequence = field.toSequence();
                uint size = sequence.size();
                Console.WriteLine();
                Console.Write("{0} {1}[{2}]=", indent_, field.localName(), field.id());
                Console.Write("{0}Sequence: {1}[{2}] = {3}", indent_, sequence.lengthName(), sequence.lengthId(), size);
                String saveIndent = indent_;
                indent_ += "  ";
                for (uint nEntry = 0; nEntry < size; ++nEntry)
                {
                    Console.WriteLine();
                    Console.Write("{0}[{1}]: ", indent_, nEntry);
                    DNFieldSet entry = sequence.entry(nEntry);
                    formatFieldSet(entry);
                }
                indent_ = saveIndent;
                Console.WriteLine();
            }

            public void formatGroup(DNField field)
            {
                DNFieldSet group = field.toGroup();
                Console.WriteLine();
                Console.Write("{0}{1}[{2}]=", indent_, field.localName(), field.id());
                Console.Write("{0}Group:", indent_);
                String saveIndent = indent_;
                indent_ = indent_ + "  ";
                formatFieldSet(group);
                indent_ = saveIndent;
            }
        };
    }
}