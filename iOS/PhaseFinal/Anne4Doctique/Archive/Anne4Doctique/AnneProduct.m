//
//  AnneProduct.m
//  MultiProductViewer
//
//  Created by JN on 2014-3-18.
//  Copyright (c) 2014 thoughtbot, inc. All rights reserved.
//

#import "AnneProduct.h"

@implementation AnneProduct

+ (instancetype)productWithDictionary:(NSDictionary *)dict {
    AnneProduct *product = [[self alloc] init];
    product.author = dict[@"Author"];
    product.description = dict[@"Text"];
    product.nbcoms = dict[@"NbComments"];
    product.date= dict[@"Date"];
    product.votemoins = dict[@"Deserved"];
    product.voteplus = dict[@"Agree"];
    product.Id = dict[@"Id"];
    /*if (dict[@"imageURL"]) {
        product.imageURL = dict[@"imageURL"];
    } else if (dict[@"imageURLString"]) {
        product.imageURL = [NSURL URLWithString:dict[@"imageURLString"]];
    }*/
    return product;
}

+ (NSArray *)productsWithArray:(NSArray *)array {
    NSMutableArray *products = [NSMutableArray arrayWithCapacity:[array count]];
    for (NSDictionary *dict in array) {
        AnneProduct *product = [self productWithDictionary:dict];
        [products addObject:product];
    }
    return products;
}
@end
