﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NIdenticon;
using NIdenticon.BlockGenerators;
using System;
using System.Drawing;
using System.Linq;
using System.Net;

namespace NIdenticonTests;

[TestClass]
public class IdenticonGeneratorTests
{
    [TestMethod]
    public void IdenticonGenerator_HasDefaults()
    {
        var i = new IdenticonGenerator();
        i.Create("test");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException), "ArgumentNullException should be thrown when no encoding is set")]
    public void IdenticonGenerator_Throws_OnNullEncoding()
    {
        var i = new IdenticonGenerator
        {
            DefaultEncoding = null
        };
        i.Create("test");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException), "ArgumentOutOfRangeException should be thrown when an unknown algorithm is specified")]
    public void IdenticonGenerator_Throws_OnInvalidAlgorithm()
    {
        var i = new IdenticonGenerator("XXX");
        i.Create("test");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException), "ArgumentOutOfRangeException should be thrown when blockshorizontal is less than 1")]
    public void IdenticonGenerator_Throws_OnInvalidBlocksHorizontal()
    {
        var i = new IdenticonGenerator
        {
            DefaultBlocks = new Size(0, 10)
        };
        i.Create("test");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException), "ArgumentOutOfRangeException should be thrown when blocksvertical is less than 1")]
    public void IdenticonGenerator_Throws_OnInvalidBlocksVertical()
    {
        var i = new IdenticonGenerator
        {
            DefaultBlocks = new Size(10, 0)
        };
        i.Create("test");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException), "ArgumentOutOfRangeException should be thrown when width is 0 or less")]
    public void IdenticonGenerator_Throws_OnInvalidWidth()
    {
        var i = new IdenticonGenerator();
        i.Create("test", new Size(0, 10));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException), "ArgumentOutOfRangeException should be thrown when height is 0 or less")]
    public void IdenticonGenerator_Throws_OnInvalidHeight()
    {
        var i = new IdenticonGenerator();
        i.Create("test", new Size(10, 0));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException), "ArgumentException should be thrown when no blockgenerators are specified")]
    public void IdenticonGenerator_Throws_OnNoBlockGenerators()
    {
        var i = new IdenticonGenerator
        {
            DefaultBlockGenerators = Array.Empty<IBlockGenerator>()
        };
        i.Create("test");
    }


    [TestMethod]
    [ExpectedException(typeof(Exception), "Exception should be thrown when an uneven horizontal number of blocks is specified and no symmetric blockgenerators are available")]
    public void IdenticonGenerator_Throws_OnNoSymmetricBlockGeneratorsForUnevenHorizontalBlocks()
    {
        var i = new IdenticonGenerator().WithBlocks(5, 5);
        //Get all NON-symmetric blockgens
        i.DefaultBlockGenerators = IdenticonGenerator.ExtendedBlockGeneratorsConfig.Where(bg => !bg.IsSymmetric).ToArray();
        i.Create("test");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException), "ArgumentNullException should be thrown when no blockgenerators are specified")]
    public void IdenticonGenerator_Throws_OnNullBlockGenerator()
    {
        var i = new IdenticonGenerator
        {
            DefaultBlockGenerators = IdenticonGenerator.DefaultBlockGeneratorsConfig.Concat(new IBlockGenerator[] { null }).ToArray()
        };
        i.Create("test");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException), "ArgumentOutOfRangeException should be thrown when width is 0 or less after rounding down to correct imagesize")]
    public void IdenticonGenerator_Throws_OnInvalidWidthAfterRounding()
    {
        var i = new IdenticonGenerator();
        i.Create("test", new Size(10, 100), Color.Red, new Size(12, 2));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException), "ArgumentOutOfRangeException should be thrown when height is 0 or less after rounding down to correct imagesize")]
    public void IdenticonGenerator_Throws_OnInvalidHeightAfterRounding()
    {
        var i = new IdenticonGenerator();
        i.Create("test", new Size(100, 10), Color.Red, new Size(2, 12));
    }

    [TestMethod]
    public void IdenticonGenerator_HasDefaultsForIPAddress()
    {
        var i = new IdenticonGenerator();
        i.Create(IPAddress.Loopback);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException), "ArgumentNullException should be thrown when IPAddress is null")]
    public void IdenticonGenerator_Throws_OnNullIPAddress()
    {
        var i = new IdenticonGenerator();
        IPAddress a = null;
        i.Create(a);
    }

    [TestMethod]
    public void IdenticonGenerator_HasDefaultsForByteArray()
    {
        var i = new IdenticonGenerator();
        i.Create(Array.Empty<byte>());
    }

    [TestMethod]
    public void IdenticonGenerator_DoesNotThrowOnNullString()
    {
        var i = new IdenticonGenerator();
        string s = null;
        i.Create(s);
    }
}
