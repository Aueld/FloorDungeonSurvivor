#include "pch-c.h"
#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include "codegen/il2cpp-codegen-metadata.h"





// 0x00000001 System.Exception System.Linq.Error::ArgumentNull(System.String)
extern void Error_ArgumentNull_m0EDA0D46D72CA692518E3E2EB75B48044D8FD41E (void);
// 0x00000002 System.Exception System.Linq.Error::MoreThanOneMatch()
extern void Error_MoreThanOneMatch_m4C4756AF34A76EF12F3B2B6D8C78DE547F0FBCF8 (void);
// 0x00000003 System.Exception System.Linq.Error::NoElements()
extern void Error_NoElements_mB89E91246572F009281D79730950808F17C3F353 (void);
// 0x00000004 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::Where(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000005 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::Select(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,TResult>)
// 0x00000006 System.Func`2<TSource,System.Boolean> System.Linq.Enumerable::CombinePredicates(System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,System.Boolean>)
// 0x00000007 System.Func`2<TSource,TResult> System.Linq.Enumerable::CombineSelectors(System.Func`2<TSource,TMiddle>,System.Func`2<TMiddle,TResult>)
// 0x00000008 System.Linq.IOrderedEnumerable`1<TSource> System.Linq.Enumerable::OrderBy(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,TKey>)
// 0x00000009 System.Linq.IOrderedEnumerable`1<TSource> System.Linq.Enumerable::ThenBy(System.Linq.IOrderedEnumerable`1<TSource>,System.Func`2<TSource,TKey>)
// 0x0000000A TSource[] System.Linq.Enumerable::ToArray(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000B System.Collections.Generic.List`1<TSource> System.Linq.Enumerable::ToList(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000C System.Collections.Generic.Dictionary`2<TKey,TElement> System.Linq.Enumerable::ToDictionary(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,TKey>,System.Func`2<TSource,TElement>)
// 0x0000000D System.Collections.Generic.Dictionary`2<TKey,TElement> System.Linq.Enumerable::ToDictionary(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,TKey>,System.Func`2<TSource,TElement>,System.Collections.Generic.IEqualityComparer`1<TKey>)
// 0x0000000E TSource System.Linq.Enumerable::First(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000F TSource System.Linq.Enumerable::Last(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000010 TSource System.Linq.Enumerable::SingleOrDefault(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000011 System.Boolean System.Linq.Enumerable::Any(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000012 System.Boolean System.Linq.Enumerable::Any(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000013 System.Int32 System.Linq.Enumerable::Count(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000014 System.Boolean System.Linq.Enumerable::Contains(System.Collections.Generic.IEnumerable`1<TSource>,TSource)
// 0x00000015 System.Boolean System.Linq.Enumerable::Contains(System.Collections.Generic.IEnumerable`1<TSource>,TSource,System.Collections.Generic.IEqualityComparer`1<TSource>)
// 0x00000016 System.Void System.Linq.Enumerable/Iterator`1::.ctor()
// 0x00000017 TSource System.Linq.Enumerable/Iterator`1::get_Current()
// 0x00000018 System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/Iterator`1::Clone()
// 0x00000019 System.Void System.Linq.Enumerable/Iterator`1::Dispose()
// 0x0000001A System.Collections.Generic.IEnumerator`1<TSource> System.Linq.Enumerable/Iterator`1::GetEnumerator()
// 0x0000001B System.Boolean System.Linq.Enumerable/Iterator`1::MoveNext()
// 0x0000001C System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/Iterator`1::Select(System.Func`2<TSource,TResult>)
// 0x0000001D System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/Iterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x0000001E System.Object System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerator.get_Current()
// 0x0000001F System.Collections.IEnumerator System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerable.GetEnumerator()
// 0x00000020 System.Void System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerator.Reset()
// 0x00000021 System.Void System.Linq.Enumerable/WhereEnumerableIterator`1::.ctor(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000022 System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereEnumerableIterator`1::Clone()
// 0x00000023 System.Void System.Linq.Enumerable/WhereEnumerableIterator`1::Dispose()
// 0x00000024 System.Boolean System.Linq.Enumerable/WhereEnumerableIterator`1::MoveNext()
// 0x00000025 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereEnumerableIterator`1::Select(System.Func`2<TSource,TResult>)
// 0x00000026 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereEnumerableIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x00000027 System.Void System.Linq.Enumerable/WhereArrayIterator`1::.ctor(TSource[],System.Func`2<TSource,System.Boolean>)
// 0x00000028 System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereArrayIterator`1::Clone()
// 0x00000029 System.Boolean System.Linq.Enumerable/WhereArrayIterator`1::MoveNext()
// 0x0000002A System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereArrayIterator`1::Select(System.Func`2<TSource,TResult>)
// 0x0000002B System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereArrayIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x0000002C System.Void System.Linq.Enumerable/WhereListIterator`1::.ctor(System.Collections.Generic.List`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x0000002D System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereListIterator`1::Clone()
// 0x0000002E System.Boolean System.Linq.Enumerable/WhereListIterator`1::MoveNext()
// 0x0000002F System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereListIterator`1::Select(System.Func`2<TSource,TResult>)
// 0x00000030 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereListIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x00000031 System.Void System.Linq.Enumerable/WhereSelectEnumerableIterator`2::.ctor(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,TResult>)
// 0x00000032 System.Linq.Enumerable/Iterator`1<TResult> System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Clone()
// 0x00000033 System.Void System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Dispose()
// 0x00000034 System.Boolean System.Linq.Enumerable/WhereSelectEnumerableIterator`2::MoveNext()
// 0x00000035 System.Collections.Generic.IEnumerable`1<TResult2> System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Select(System.Func`2<TResult,TResult2>)
// 0x00000036 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Where(System.Func`2<TResult,System.Boolean>)
// 0x00000037 System.Void System.Linq.Enumerable/WhereSelectArrayIterator`2::.ctor(TSource[],System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,TResult>)
// 0x00000038 System.Linq.Enumerable/Iterator`1<TResult> System.Linq.Enumerable/WhereSelectArrayIterator`2::Clone()
// 0x00000039 System.Boolean System.Linq.Enumerable/WhereSelectArrayIterator`2::MoveNext()
// 0x0000003A System.Collections.Generic.IEnumerable`1<TResult2> System.Linq.Enumerable/WhereSelectArrayIterator`2::Select(System.Func`2<TResult,TResult2>)
// 0x0000003B System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereSelectArrayIterator`2::Where(System.Func`2<TResult,System.Boolean>)
// 0x0000003C System.Void System.Linq.Enumerable/WhereSelectListIterator`2::.ctor(System.Collections.Generic.List`1<TSource>,System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,TResult>)
// 0x0000003D System.Linq.Enumerable/Iterator`1<TResult> System.Linq.Enumerable/WhereSelectListIterator`2::Clone()
// 0x0000003E System.Boolean System.Linq.Enumerable/WhereSelectListIterator`2::MoveNext()
// 0x0000003F System.Collections.Generic.IEnumerable`1<TResult2> System.Linq.Enumerable/WhereSelectListIterator`2::Select(System.Func`2<TResult,TResult2>)
// 0x00000040 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereSelectListIterator`2::Where(System.Func`2<TResult,System.Boolean>)
// 0x00000041 System.Void System.Linq.Enumerable/<>c__DisplayClass6_0`1::.ctor()
// 0x00000042 System.Boolean System.Linq.Enumerable/<>c__DisplayClass6_0`1::<CombinePredicates>b__0(TSource)
// 0x00000043 System.Void System.Linq.Enumerable/<>c__DisplayClass7_0`3::.ctor()
// 0x00000044 TResult System.Linq.Enumerable/<>c__DisplayClass7_0`3::<CombineSelectors>b__0(TSource)
// 0x00000045 System.Linq.IOrderedEnumerable`1<TElement> System.Linq.IOrderedEnumerable`1::CreateOrderedEnumerable(System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean)
// 0x00000046 System.Collections.Generic.IEnumerator`1<TElement> System.Linq.OrderedEnumerable`1::GetEnumerator()
// 0x00000047 System.Linq.EnumerableSorter`1<TElement> System.Linq.OrderedEnumerable`1::GetEnumerableSorter(System.Linq.EnumerableSorter`1<TElement>)
// 0x00000048 System.Collections.IEnumerator System.Linq.OrderedEnumerable`1::System.Collections.IEnumerable.GetEnumerator()
// 0x00000049 System.Linq.IOrderedEnumerable`1<TElement> System.Linq.OrderedEnumerable`1::System.Linq.IOrderedEnumerable<TElement>.CreateOrderedEnumerable(System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean)
// 0x0000004A System.Void System.Linq.OrderedEnumerable`1::.ctor()
// 0x0000004B System.Void System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::.ctor(System.Int32)
// 0x0000004C System.Void System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.IDisposable.Dispose()
// 0x0000004D System.Boolean System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::MoveNext()
// 0x0000004E TElement System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.Collections.Generic.IEnumerator<TElement>.get_Current()
// 0x0000004F System.Void System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.Collections.IEnumerator.Reset()
// 0x00000050 System.Object System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.Collections.IEnumerator.get_Current()
// 0x00000051 System.Void System.Linq.OrderedEnumerable`2::.ctor(System.Collections.Generic.IEnumerable`1<TElement>,System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean)
// 0x00000052 System.Linq.EnumerableSorter`1<TElement> System.Linq.OrderedEnumerable`2::GetEnumerableSorter(System.Linq.EnumerableSorter`1<TElement>)
// 0x00000053 System.Void System.Linq.EnumerableSorter`1::ComputeKeys(TElement[],System.Int32)
// 0x00000054 System.Int32 System.Linq.EnumerableSorter`1::CompareKeys(System.Int32,System.Int32)
// 0x00000055 System.Int32[] System.Linq.EnumerableSorter`1::Sort(TElement[],System.Int32)
// 0x00000056 System.Void System.Linq.EnumerableSorter`1::QuickSort(System.Int32[],System.Int32,System.Int32)
// 0x00000057 System.Void System.Linq.EnumerableSorter`1::.ctor()
// 0x00000058 System.Void System.Linq.EnumerableSorter`2::.ctor(System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean,System.Linq.EnumerableSorter`1<TElement>)
// 0x00000059 System.Void System.Linq.EnumerableSorter`2::ComputeKeys(TElement[],System.Int32)
// 0x0000005A System.Int32 System.Linq.EnumerableSorter`2::CompareKeys(System.Int32,System.Int32)
// 0x0000005B System.Void System.Linq.Buffer`1::.ctor(System.Collections.Generic.IEnumerable`1<TElement>)
// 0x0000005C TElement[] System.Linq.Buffer`1::ToArray()
// 0x0000005D System.Void System.Collections.Generic.HashSet`1::.ctor()
// 0x0000005E System.Void System.Collections.Generic.HashSet`1::.ctor(System.Collections.Generic.IEqualityComparer`1<T>)
// 0x0000005F System.Void System.Collections.Generic.HashSet`1::.ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
// 0x00000060 System.Void System.Collections.Generic.HashSet`1::System.Collections.Generic.ICollection<T>.Add(T)
// 0x00000061 System.Void System.Collections.Generic.HashSet`1::Clear()
// 0x00000062 System.Boolean System.Collections.Generic.HashSet`1::Contains(T)
// 0x00000063 System.Void System.Collections.Generic.HashSet`1::CopyTo(T[],System.Int32)
// 0x00000064 System.Boolean System.Collections.Generic.HashSet`1::Remove(T)
// 0x00000065 System.Int32 System.Collections.Generic.HashSet`1::get_Count()
// 0x00000066 System.Boolean System.Collections.Generic.HashSet`1::System.Collections.Generic.ICollection<T>.get_IsReadOnly()
// 0x00000067 System.Collections.Generic.HashSet`1/Enumerator<T> System.Collections.Generic.HashSet`1::GetEnumerator()
// 0x00000068 System.Collections.Generic.IEnumerator`1<T> System.Collections.Generic.HashSet`1::System.Collections.Generic.IEnumerable<T>.GetEnumerator()
// 0x00000069 System.Collections.IEnumerator System.Collections.Generic.HashSet`1::System.Collections.IEnumerable.GetEnumerator()
// 0x0000006A System.Void System.Collections.Generic.HashSet`1::GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
// 0x0000006B System.Void System.Collections.Generic.HashSet`1::OnDeserialization(System.Object)
// 0x0000006C System.Boolean System.Collections.Generic.HashSet`1::Add(T)
// 0x0000006D System.Void System.Collections.Generic.HashSet`1::CopyTo(T[])
// 0x0000006E System.Void System.Collections.Generic.HashSet`1::CopyTo(T[],System.Int32,System.Int32)
// 0x0000006F System.Void System.Collections.Generic.HashSet`1::Initialize(System.Int32)
// 0x00000070 System.Void System.Collections.Generic.HashSet`1::IncreaseCapacity()
// 0x00000071 System.Void System.Collections.Generic.HashSet`1::SetCapacity(System.Int32)
// 0x00000072 System.Boolean System.Collections.Generic.HashSet`1::AddIfNotPresent(T)
// 0x00000073 System.Int32 System.Collections.Generic.HashSet`1::InternalGetHashCode(T)
// 0x00000074 System.Void System.Collections.Generic.HashSet`1/Enumerator::.ctor(System.Collections.Generic.HashSet`1<T>)
// 0x00000075 System.Void System.Collections.Generic.HashSet`1/Enumerator::Dispose()
// 0x00000076 System.Boolean System.Collections.Generic.HashSet`1/Enumerator::MoveNext()
// 0x00000077 T System.Collections.Generic.HashSet`1/Enumerator::get_Current()
// 0x00000078 System.Object System.Collections.Generic.HashSet`1/Enumerator::System.Collections.IEnumerator.get_Current()
// 0x00000079 System.Void System.Collections.Generic.HashSet`1/Enumerator::System.Collections.IEnumerator.Reset()
static Il2CppMethodPointer s_methodPointers[121] = 
{
	Error_ArgumentNull_m0EDA0D46D72CA692518E3E2EB75B48044D8FD41E,
	Error_MoreThanOneMatch_m4C4756AF34A76EF12F3B2B6D8C78DE547F0FBCF8,
	Error_NoElements_mB89E91246572F009281D79730950808F17C3F353,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
};
static const int32_t s_InvokerIndices[121] = 
{
	2443,
	2530,
	2530,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
};
static const Il2CppTokenRangePair s_rgctxIndices[42] = 
{
	{ 0x02000004, { 70, 4 } },
	{ 0x02000005, { 74, 9 } },
	{ 0x02000006, { 85, 7 } },
	{ 0x02000007, { 94, 10 } },
	{ 0x02000008, { 106, 11 } },
	{ 0x02000009, { 120, 9 } },
	{ 0x0200000A, { 132, 12 } },
	{ 0x0200000B, { 147, 1 } },
	{ 0x0200000C, { 148, 2 } },
	{ 0x0200000E, { 150, 3 } },
	{ 0x0200000F, { 155, 5 } },
	{ 0x02000010, { 160, 7 } },
	{ 0x02000011, { 167, 3 } },
	{ 0x02000012, { 170, 7 } },
	{ 0x02000013, { 177, 4 } },
	{ 0x02000014, { 181, 21 } },
	{ 0x02000016, { 202, 2 } },
	{ 0x06000004, { 0, 10 } },
	{ 0x06000005, { 10, 10 } },
	{ 0x06000006, { 20, 5 } },
	{ 0x06000007, { 25, 5 } },
	{ 0x06000008, { 30, 2 } },
	{ 0x06000009, { 32, 1 } },
	{ 0x0600000A, { 33, 3 } },
	{ 0x0600000B, { 36, 2 } },
	{ 0x0600000C, { 38, 1 } },
	{ 0x0600000D, { 39, 7 } },
	{ 0x0600000E, { 46, 4 } },
	{ 0x0600000F, { 50, 4 } },
	{ 0x06000010, { 54, 3 } },
	{ 0x06000011, { 57, 1 } },
	{ 0x06000012, { 58, 3 } },
	{ 0x06000013, { 61, 2 } },
	{ 0x06000014, { 63, 2 } },
	{ 0x06000015, { 65, 5 } },
	{ 0x06000025, { 83, 2 } },
	{ 0x0600002A, { 92, 2 } },
	{ 0x0600002F, { 104, 2 } },
	{ 0x06000035, { 117, 3 } },
	{ 0x0600003A, { 129, 3 } },
	{ 0x0600003F, { 144, 3 } },
	{ 0x06000049, { 153, 2 } },
};
static const Il2CppRGCTXDefinition s_rgctxValues[204] = 
{
	{ (Il2CppRGCTXDataType)2, 1262 },
	{ (Il2CppRGCTXDataType)3, 4801 },
	{ (Il2CppRGCTXDataType)2, 2112 },
	{ (Il2CppRGCTXDataType)2, 1791 },
	{ (Il2CppRGCTXDataType)3, 8365 },
	{ (Il2CppRGCTXDataType)2, 1348 },
	{ (Il2CppRGCTXDataType)2, 1798 },
	{ (Il2CppRGCTXDataType)3, 8388 },
	{ (Il2CppRGCTXDataType)2, 1793 },
	{ (Il2CppRGCTXDataType)3, 8372 },
	{ (Il2CppRGCTXDataType)2, 1263 },
	{ (Il2CppRGCTXDataType)3, 4802 },
	{ (Il2CppRGCTXDataType)2, 2133 },
	{ (Il2CppRGCTXDataType)2, 1800 },
	{ (Il2CppRGCTXDataType)3, 8395 },
	{ (Il2CppRGCTXDataType)2, 1365 },
	{ (Il2CppRGCTXDataType)2, 1808 },
	{ (Il2CppRGCTXDataType)3, 8423 },
	{ (Il2CppRGCTXDataType)2, 1804 },
	{ (Il2CppRGCTXDataType)3, 8408 },
	{ (Il2CppRGCTXDataType)2, 441 },
	{ (Il2CppRGCTXDataType)3, 19 },
	{ (Il2CppRGCTXDataType)3, 20 },
	{ (Il2CppRGCTXDataType)2, 802 },
	{ (Il2CppRGCTXDataType)3, 3564 },
	{ (Il2CppRGCTXDataType)2, 442 },
	{ (Il2CppRGCTXDataType)3, 25 },
	{ (Il2CppRGCTXDataType)3, 26 },
	{ (Il2CppRGCTXDataType)2, 812 },
	{ (Il2CppRGCTXDataType)3, 3568 },
	{ (Il2CppRGCTXDataType)2, 1608 },
	{ (Il2CppRGCTXDataType)3, 7388 },
	{ (Il2CppRGCTXDataType)3, 3964 },
	{ (Il2CppRGCTXDataType)2, 500 },
	{ (Il2CppRGCTXDataType)3, 519 },
	{ (Il2CppRGCTXDataType)3, 520 },
	{ (Il2CppRGCTXDataType)2, 1349 },
	{ (Il2CppRGCTXDataType)3, 5300 },
	{ (Il2CppRGCTXDataType)3, 10028 },
	{ (Il2CppRGCTXDataType)2, 570 },
	{ (Il2CppRGCTXDataType)3, 938 },
	{ (Il2CppRGCTXDataType)2, 1016 },
	{ (Il2CppRGCTXDataType)2, 1068 },
	{ (Il2CppRGCTXDataType)3, 3566 },
	{ (Il2CppRGCTXDataType)3, 3567 },
	{ (Il2CppRGCTXDataType)3, 939 },
	{ (Il2CppRGCTXDataType)2, 1202 },
	{ (Il2CppRGCTXDataType)2, 918 },
	{ (Il2CppRGCTXDataType)2, 1002 },
	{ (Il2CppRGCTXDataType)2, 1065 },
	{ (Il2CppRGCTXDataType)2, 1203 },
	{ (Il2CppRGCTXDataType)2, 919 },
	{ (Il2CppRGCTXDataType)2, 1003 },
	{ (Il2CppRGCTXDataType)2, 1066 },
	{ (Il2CppRGCTXDataType)2, 1004 },
	{ (Il2CppRGCTXDataType)2, 1067 },
	{ (Il2CppRGCTXDataType)3, 3565 },
	{ (Il2CppRGCTXDataType)2, 995 },
	{ (Il2CppRGCTXDataType)2, 996 },
	{ (Il2CppRGCTXDataType)2, 1063 },
	{ (Il2CppRGCTXDataType)3, 3563 },
	{ (Il2CppRGCTXDataType)2, 917 },
	{ (Il2CppRGCTXDataType)2, 1001 },
	{ (Il2CppRGCTXDataType)2, 916 },
	{ (Il2CppRGCTXDataType)3, 9997 },
	{ (Il2CppRGCTXDataType)3, 3176 },
	{ (Il2CppRGCTXDataType)2, 716 },
	{ (Il2CppRGCTXDataType)2, 998 },
	{ (Il2CppRGCTXDataType)2, 1064 },
	{ (Il2CppRGCTXDataType)2, 1115 },
	{ (Il2CppRGCTXDataType)3, 4803 },
	{ (Il2CppRGCTXDataType)3, 4805 },
	{ (Il2CppRGCTXDataType)2, 308 },
	{ (Il2CppRGCTXDataType)3, 4804 },
	{ (Il2CppRGCTXDataType)3, 4813 },
	{ (Il2CppRGCTXDataType)2, 1266 },
	{ (Il2CppRGCTXDataType)2, 1794 },
	{ (Il2CppRGCTXDataType)3, 8373 },
	{ (Il2CppRGCTXDataType)3, 4814 },
	{ (Il2CppRGCTXDataType)2, 1038 },
	{ (Il2CppRGCTXDataType)2, 1086 },
	{ (Il2CppRGCTXDataType)3, 3574 },
	{ (Il2CppRGCTXDataType)3, 9987 },
	{ (Il2CppRGCTXDataType)2, 1805 },
	{ (Il2CppRGCTXDataType)3, 8409 },
	{ (Il2CppRGCTXDataType)3, 4806 },
	{ (Il2CppRGCTXDataType)2, 1265 },
	{ (Il2CppRGCTXDataType)2, 1792 },
	{ (Il2CppRGCTXDataType)3, 8366 },
	{ (Il2CppRGCTXDataType)3, 3573 },
	{ (Il2CppRGCTXDataType)3, 4807 },
	{ (Il2CppRGCTXDataType)3, 9986 },
	{ (Il2CppRGCTXDataType)2, 1801 },
	{ (Il2CppRGCTXDataType)3, 8396 },
	{ (Il2CppRGCTXDataType)3, 4820 },
	{ (Il2CppRGCTXDataType)2, 1267 },
	{ (Il2CppRGCTXDataType)2, 1799 },
	{ (Il2CppRGCTXDataType)3, 8389 },
	{ (Il2CppRGCTXDataType)3, 5343 },
	{ (Il2CppRGCTXDataType)3, 2549 },
	{ (Il2CppRGCTXDataType)3, 3575 },
	{ (Il2CppRGCTXDataType)3, 2548 },
	{ (Il2CppRGCTXDataType)3, 4821 },
	{ (Il2CppRGCTXDataType)3, 9988 },
	{ (Il2CppRGCTXDataType)2, 1809 },
	{ (Il2CppRGCTXDataType)3, 8424 },
	{ (Il2CppRGCTXDataType)3, 4834 },
	{ (Il2CppRGCTXDataType)2, 1269 },
	{ (Il2CppRGCTXDataType)2, 1807 },
	{ (Il2CppRGCTXDataType)3, 8411 },
	{ (Il2CppRGCTXDataType)3, 4835 },
	{ (Il2CppRGCTXDataType)2, 1041 },
	{ (Il2CppRGCTXDataType)2, 1089 },
	{ (Il2CppRGCTXDataType)3, 3579 },
	{ (Il2CppRGCTXDataType)3, 3578 },
	{ (Il2CppRGCTXDataType)2, 1796 },
	{ (Il2CppRGCTXDataType)3, 8375 },
	{ (Il2CppRGCTXDataType)3, 9992 },
	{ (Il2CppRGCTXDataType)2, 1806 },
	{ (Il2CppRGCTXDataType)3, 8410 },
	{ (Il2CppRGCTXDataType)3, 4827 },
	{ (Il2CppRGCTXDataType)2, 1268 },
	{ (Il2CppRGCTXDataType)2, 1803 },
	{ (Il2CppRGCTXDataType)3, 8398 },
	{ (Il2CppRGCTXDataType)3, 3577 },
	{ (Il2CppRGCTXDataType)3, 3576 },
	{ (Il2CppRGCTXDataType)3, 4828 },
	{ (Il2CppRGCTXDataType)2, 1795 },
	{ (Il2CppRGCTXDataType)3, 8374 },
	{ (Il2CppRGCTXDataType)3, 9991 },
	{ (Il2CppRGCTXDataType)2, 1802 },
	{ (Il2CppRGCTXDataType)3, 8397 },
	{ (Il2CppRGCTXDataType)3, 4841 },
	{ (Il2CppRGCTXDataType)2, 1270 },
	{ (Il2CppRGCTXDataType)2, 1811 },
	{ (Il2CppRGCTXDataType)3, 8426 },
	{ (Il2CppRGCTXDataType)3, 5344 },
	{ (Il2CppRGCTXDataType)3, 2551 },
	{ (Il2CppRGCTXDataType)3, 3581 },
	{ (Il2CppRGCTXDataType)3, 3580 },
	{ (Il2CppRGCTXDataType)3, 2550 },
	{ (Il2CppRGCTXDataType)3, 4842 },
	{ (Il2CppRGCTXDataType)2, 1797 },
	{ (Il2CppRGCTXDataType)3, 8376 },
	{ (Il2CppRGCTXDataType)3, 9993 },
	{ (Il2CppRGCTXDataType)2, 1810 },
	{ (Il2CppRGCTXDataType)3, 8425 },
	{ (Il2CppRGCTXDataType)3, 3571 },
	{ (Il2CppRGCTXDataType)3, 3572 },
	{ (Il2CppRGCTXDataType)3, 3582 },
	{ (Il2CppRGCTXDataType)2, 443 },
	{ (Il2CppRGCTXDataType)3, 29 },
	{ (Il2CppRGCTXDataType)3, 7375 },
	{ (Il2CppRGCTXDataType)2, 1609 },
	{ (Il2CppRGCTXDataType)3, 7389 },
	{ (Il2CppRGCTXDataType)2, 501 },
	{ (Il2CppRGCTXDataType)3, 521 },
	{ (Il2CppRGCTXDataType)3, 7381 },
	{ (Il2CppRGCTXDataType)3, 2530 },
	{ (Il2CppRGCTXDataType)2, 327 },
	{ (Il2CppRGCTXDataType)3, 7376 },
	{ (Il2CppRGCTXDataType)2, 1605 },
	{ (Il2CppRGCTXDataType)3, 549 },
	{ (Il2CppRGCTXDataType)2, 513 },
	{ (Il2CppRGCTXDataType)2, 702 },
	{ (Il2CppRGCTXDataType)3, 2536 },
	{ (Il2CppRGCTXDataType)3, 7377 },
	{ (Il2CppRGCTXDataType)3, 2525 },
	{ (Il2CppRGCTXDataType)3, 2526 },
	{ (Il2CppRGCTXDataType)3, 2524 },
	{ (Il2CppRGCTXDataType)3, 2527 },
	{ (Il2CppRGCTXDataType)2, 698 },
	{ (Il2CppRGCTXDataType)2, 2173 },
	{ (Il2CppRGCTXDataType)3, 3570 },
	{ (Il2CppRGCTXDataType)3, 2529 },
	{ (Il2CppRGCTXDataType)2, 983 },
	{ (Il2CppRGCTXDataType)3, 2528 },
	{ (Il2CppRGCTXDataType)2, 920 },
	{ (Il2CppRGCTXDataType)2, 2136 },
	{ (Il2CppRGCTXDataType)2, 1017 },
	{ (Il2CppRGCTXDataType)2, 1069 },
	{ (Il2CppRGCTXDataType)3, 3192 },
	{ (Il2CppRGCTXDataType)2, 724 },
	{ (Il2CppRGCTXDataType)3, 3817 },
	{ (Il2CppRGCTXDataType)3, 3818 },
	{ (Il2CppRGCTXDataType)3, 3823 },
	{ (Il2CppRGCTXDataType)2, 1123 },
	{ (Il2CppRGCTXDataType)3, 3820 },
	{ (Il2CppRGCTXDataType)3, 10273 },
	{ (Il2CppRGCTXDataType)2, 703 },
	{ (Il2CppRGCTXDataType)3, 2543 },
	{ (Il2CppRGCTXDataType)1, 980 },
	{ (Il2CppRGCTXDataType)2, 2144 },
	{ (Il2CppRGCTXDataType)3, 3819 },
	{ (Il2CppRGCTXDataType)1, 2144 },
	{ (Il2CppRGCTXDataType)1, 1123 },
	{ (Il2CppRGCTXDataType)2, 2187 },
	{ (Il2CppRGCTXDataType)2, 2144 },
	{ (Il2CppRGCTXDataType)3, 3824 },
	{ (Il2CppRGCTXDataType)3, 3822 },
	{ (Il2CppRGCTXDataType)3, 3821 },
	{ (Il2CppRGCTXDataType)2, 216 },
	{ (Il2CppRGCTXDataType)3, 2552 },
	{ (Il2CppRGCTXDataType)2, 317 },
};
extern const CustomAttributesCacheGenerator g_System_Core_AttributeGenerators[];
IL2CPP_EXTERN_C const Il2CppCodeGenModule g_System_Core_CodeGenModule;
const Il2CppCodeGenModule g_System_Core_CodeGenModule = 
{
	"System.Core.dll",
	121,
	s_methodPointers,
	0,
	NULL,
	s_InvokerIndices,
	0,
	NULL,
	42,
	s_rgctxIndices,
	204,
	s_rgctxValues,
	NULL,
	g_System_Core_AttributeGenerators,
	NULL, // module initializer,
	NULL,
	NULL,
	NULL,
};
