// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: sinhvien.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace QuanLySvGRPC.Protos {
  public static partial class SinhVienRPC
  {
    static readonly string __ServiceName = "sinhvien.SinhVienRPC";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::QuanLySvGRPC.Protos.SinhVienRequest> __Marshaller_sinhvien_SinhVienRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::QuanLySvGRPC.Protos.SinhVienRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::QuanLySvGRPC.Protos.SinhVienReply> __Marshaller_sinhvien_SinhVienReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::QuanLySvGRPC.Protos.SinhVienReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::QuanLySvGRPC.Protos.ListSinhVienReply> __Marshaller_sinhvien_ListSinhVienReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::QuanLySvGRPC.Protos.ListSinhVienReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::QuanLySvGRPC.Protos.SinhVienModelRequest> __Marshaller_sinhvien_SinhVienModelRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::QuanLySvGRPC.Protos.SinhVienModelRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.BoolValue> __Marshaller_google_protobuf_BoolValue = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Protobuf.WellKnownTypes.BoolValue.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::QuanLySvGRPC.Protos.LopHocRequest> __Marshaller_sinhvien_LopHocRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::QuanLySvGRPC.Protos.LopHocRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::QuanLySvGRPC.Protos.ListLopHocReply> __Marshaller_sinhvien_ListLopHocReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::QuanLySvGRPC.Protos.ListLopHocReply.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::QuanLySvGRPC.Protos.SinhVienRequest, global::QuanLySvGRPC.Protos.SinhVienReply> __Method_GetSinhVienDetail = new grpc::Method<global::QuanLySvGRPC.Protos.SinhVienRequest, global::QuanLySvGRPC.Protos.SinhVienReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetSinhVienDetail",
        __Marshaller_sinhvien_SinhVienRequest,
        __Marshaller_sinhvien_SinhVienReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::QuanLySvGRPC.Protos.SinhVienRequest, global::QuanLySvGRPC.Protos.ListSinhVienReply> __Method_GetAllSinhVien = new grpc::Method<global::QuanLySvGRPC.Protos.SinhVienRequest, global::QuanLySvGRPC.Protos.ListSinhVienReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllSinhVien",
        __Marshaller_sinhvien_SinhVienRequest,
        __Marshaller_sinhvien_ListSinhVienReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::QuanLySvGRPC.Protos.SinhVienModelRequest, global::QuanLySvGRPC.Protos.SinhVienReply> __Method_UpdateSinhVien = new grpc::Method<global::QuanLySvGRPC.Protos.SinhVienModelRequest, global::QuanLySvGRPC.Protos.SinhVienReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateSinhVien",
        __Marshaller_sinhvien_SinhVienModelRequest,
        __Marshaller_sinhvien_SinhVienReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::QuanLySvGRPC.Protos.SinhVienRequest, global::Google.Protobuf.WellKnownTypes.BoolValue> __Method_DeleteSinhVien = new grpc::Method<global::QuanLySvGRPC.Protos.SinhVienRequest, global::Google.Protobuf.WellKnownTypes.BoolValue>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteSinhVien",
        __Marshaller_sinhvien_SinhVienRequest,
        __Marshaller_google_protobuf_BoolValue);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::QuanLySvGRPC.Protos.SinhVienModelRequest, global::QuanLySvGRPC.Protos.SinhVienReply> __Method_AddSinhVien = new grpc::Method<global::QuanLySvGRPC.Protos.SinhVienModelRequest, global::QuanLySvGRPC.Protos.SinhVienReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddSinhVien",
        __Marshaller_sinhvien_SinhVienModelRequest,
        __Marshaller_sinhvien_SinhVienReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::QuanLySvGRPC.Protos.SinhVienRequest, global::QuanLySvGRPC.Protos.ListSinhVienReply> __Method_ArrangeSinhVien = new grpc::Method<global::QuanLySvGRPC.Protos.SinhVienRequest, global::QuanLySvGRPC.Protos.ListSinhVienReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ArrangeSinhVien",
        __Marshaller_sinhvien_SinhVienRequest,
        __Marshaller_sinhvien_ListSinhVienReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::QuanLySvGRPC.Protos.LopHocRequest, global::QuanLySvGRPC.Protos.ListLopHocReply> __Method_GetAllLopHoc = new grpc::Method<global::QuanLySvGRPC.Protos.LopHocRequest, global::QuanLySvGRPC.Protos.ListLopHocReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllLopHoc",
        __Marshaller_sinhvien_LopHocRequest,
        __Marshaller_sinhvien_ListLopHocReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::QuanLySvGRPC.Protos.SinhvienReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for SinhVienRPC</summary>
    public partial class SinhVienRPCClient : grpc::ClientBase<SinhVienRPCClient>
    {
      /// <summary>Creates a new client for SinhVienRPC</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public SinhVienRPCClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for SinhVienRPC that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public SinhVienRPCClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected SinhVienRPCClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected SinhVienRPCClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::QuanLySvGRPC.Protos.SinhVienReply GetSinhVienDetail(global::QuanLySvGRPC.Protos.SinhVienRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetSinhVienDetail(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::QuanLySvGRPC.Protos.SinhVienReply GetSinhVienDetail(global::QuanLySvGRPC.Protos.SinhVienRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetSinhVienDetail, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::QuanLySvGRPC.Protos.SinhVienReply> GetSinhVienDetailAsync(global::QuanLySvGRPC.Protos.SinhVienRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetSinhVienDetailAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::QuanLySvGRPC.Protos.SinhVienReply> GetSinhVienDetailAsync(global::QuanLySvGRPC.Protos.SinhVienRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetSinhVienDetail, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::QuanLySvGRPC.Protos.ListSinhVienReply GetAllSinhVien(global::QuanLySvGRPC.Protos.SinhVienRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllSinhVien(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::QuanLySvGRPC.Protos.ListSinhVienReply GetAllSinhVien(global::QuanLySvGRPC.Protos.SinhVienRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetAllSinhVien, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::QuanLySvGRPC.Protos.ListSinhVienReply> GetAllSinhVienAsync(global::QuanLySvGRPC.Protos.SinhVienRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllSinhVienAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::QuanLySvGRPC.Protos.ListSinhVienReply> GetAllSinhVienAsync(global::QuanLySvGRPC.Protos.SinhVienRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetAllSinhVien, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::QuanLySvGRPC.Protos.SinhVienReply UpdateSinhVien(global::QuanLySvGRPC.Protos.SinhVienModelRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateSinhVien(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::QuanLySvGRPC.Protos.SinhVienReply UpdateSinhVien(global::QuanLySvGRPC.Protos.SinhVienModelRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_UpdateSinhVien, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::QuanLySvGRPC.Protos.SinhVienReply> UpdateSinhVienAsync(global::QuanLySvGRPC.Protos.SinhVienModelRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateSinhVienAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::QuanLySvGRPC.Protos.SinhVienReply> UpdateSinhVienAsync(global::QuanLySvGRPC.Protos.SinhVienModelRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_UpdateSinhVien, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.BoolValue DeleteSinhVien(global::QuanLySvGRPC.Protos.SinhVienRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteSinhVien(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.BoolValue DeleteSinhVien(global::QuanLySvGRPC.Protos.SinhVienRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_DeleteSinhVien, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.BoolValue> DeleteSinhVienAsync(global::QuanLySvGRPC.Protos.SinhVienRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteSinhVienAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.BoolValue> DeleteSinhVienAsync(global::QuanLySvGRPC.Protos.SinhVienRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_DeleteSinhVien, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::QuanLySvGRPC.Protos.SinhVienReply AddSinhVien(global::QuanLySvGRPC.Protos.SinhVienModelRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddSinhVien(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::QuanLySvGRPC.Protos.SinhVienReply AddSinhVien(global::QuanLySvGRPC.Protos.SinhVienModelRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_AddSinhVien, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::QuanLySvGRPC.Protos.SinhVienReply> AddSinhVienAsync(global::QuanLySvGRPC.Protos.SinhVienModelRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddSinhVienAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::QuanLySvGRPC.Protos.SinhVienReply> AddSinhVienAsync(global::QuanLySvGRPC.Protos.SinhVienModelRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_AddSinhVien, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::QuanLySvGRPC.Protos.ListSinhVienReply ArrangeSinhVien(global::QuanLySvGRPC.Protos.SinhVienRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ArrangeSinhVien(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::QuanLySvGRPC.Protos.ListSinhVienReply ArrangeSinhVien(global::QuanLySvGRPC.Protos.SinhVienRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_ArrangeSinhVien, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::QuanLySvGRPC.Protos.ListSinhVienReply> ArrangeSinhVienAsync(global::QuanLySvGRPC.Protos.SinhVienRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ArrangeSinhVienAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::QuanLySvGRPC.Protos.ListSinhVienReply> ArrangeSinhVienAsync(global::QuanLySvGRPC.Protos.SinhVienRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_ArrangeSinhVien, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::QuanLySvGRPC.Protos.ListLopHocReply GetAllLopHoc(global::QuanLySvGRPC.Protos.LopHocRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllLopHoc(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::QuanLySvGRPC.Protos.ListLopHocReply GetAllLopHoc(global::QuanLySvGRPC.Protos.LopHocRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetAllLopHoc, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::QuanLySvGRPC.Protos.ListLopHocReply> GetAllLopHocAsync(global::QuanLySvGRPC.Protos.LopHocRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllLopHocAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::QuanLySvGRPC.Protos.ListLopHocReply> GetAllLopHocAsync(global::QuanLySvGRPC.Protos.LopHocRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetAllLopHoc, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override SinhVienRPCClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new SinhVienRPCClient(configuration);
      }
    }

  }
}
#endregion
