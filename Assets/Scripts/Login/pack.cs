using System;
/// <summary>
/// 大端->高位在前
/// 小端->低位在前
/// </summary>

/*
0（零）xFF是16进制的255，也就是二进制的 1111，1111

& AND 按位与操作，同时为1时才是1，否则为0.

————位移运算计算机中存的都是数的补码，所以位移运算都是对补码而言的————

<< 左移 右补0

>> 有符号右移 左补符号位，即：如果符号位是1 就左补1，如果符号位是0 就左补0

>>>无符号右移 ，顾名思义，统一左补0



要想知道为什么？我们应该想想，我们的目的是干什么的？开始已经讲了：先取高8位写入，再写入低8位.。

0000,0000,0000,0011      3的二进制原码，假设要写入的short字符对应的unicode码是3。

0000,0000,0000,0000      这是">>>8"的结果                         

1111,1111        然后再 &0XFF                                                                          

0000,0000       最终结果                                                                                    

这就得到了 3的原码0000，0000，0000，0011 的高8位。

0000,0000,0000,0011          >>>0还是源码本身不变

1111,1111        &0XFF                                                                        

0000,0011        最终结果 
这就得到了 3的原码0000，0000，0000，0011 的低8位。

其实，用有符号的右移>>也一样得到高/低8位，因为右移操作不改变数本身，
返回一个新值，就像String。所以&0xFF就像计算机中的一把剪刀，
当‘&’两边的数bit位数相同时不改变数的大小，只是专门截出一个字节的长度。
同理，&0x0F呢？得到4bits
*/
namespace networkre
{
    public class pcak
    {
        //数据类型编码算法
        //将int转为低字节在前，高字节在后的byte数组
        public static byte[] InttoByteArray(int n)
        {
            byte[] b = new byte[4];
            b[0] = (byte)(n & 0xff);
            b[1] = (byte)(n >> 8 & 0xff);
            b[2] = (byte)(n >> 16 & 0xff);
            b[3] = (byte)(n >> 24 & 0xff);
            return b;
        }

        //将short转为低字节在前，高字节在后的byte数组
        public static byte[] ShorttoByteArray(short n)
        {
            byte[] b = new byte[2];
            b[1] = (byte)(n & 0xff);
            b[0] = (byte)(n >> 8 & 0xff);
            return b;
        }

        //将int类型网络字节转化为主机字节算法
        public static int ByteArraytoInt(byte[] b)
        {
            int iOutcome = 0;
            byte bLoop;
            for (int i = 0; i < 4; i++)
            {
                bLoop = b[i];
                iOutcome += (bLoop & 0xff) << (8 * i);
            }
            return iOutcome;
        }

        //将short类型的网络字节转化为主机字节算法
        public static short ByteArraytoShort(byte[] b)
        {
            short iOutcome = 0;
            byte bLoop;
            for (int i = 0; i < 2; i++)
            {
                bLoop = b[i];
                iOutcome += (short)((bLoop & 0xff) << (8 * i));
            }
            return iOutcome;
        }

        /*
        //C#中ANSI字符数组转化为String字符串
        private static String ByteArraytoString(byte[] b)
        {
            String retstr = "";
            try
            {
                retstr = new String(b, string, ,System.Text.Encoding.ASCII);
            }
            catch(Exception e)
            {

            }
            return retstr.Trim();
        }

        //C#中String字符串转换为ANSI字符数组
        private static byte[] StringtoByteArray(String str)
        {
            byte[] retBytes = null;
            try
            {
                retBytes = str.
            }
        }
        */

    }
}


